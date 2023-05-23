using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using ShaderEffects;

// By @Madhu
// This calss is the View part of the CastleRaided text animation which is responsible of the animation of the text
public class CastleRaidedView : MonoBehaviour
{

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _textMsg;
    [SerializeField] private ParticleSystem _particleSys;
    private RectTransform _backgroundRectTransform;
    private RectTransform _flasRectTransform;
    private RectTransform _textRectTransform;
    private Image _flashImg;
    private Image _backgroundImg;

    private TextMeshProUGUI _textTmp;

    private Material _material;
    
    //Animation Parameters 
    [SerializeField] private Vector2 _backgroundInitSize;
    [SerializeField] private Vector2 _backgroundFinalSize;
    [SerializeField] private Vector2 _flashSize;
    [SerializeField] private Vector2 _initMsgSize;
    [SerializeField] private Vector2 _finalMsgSize;
    [SerializeField] private float _ghostBoostMin;
    [SerializeField] private float _ghostBoostMax;
    [SerializeField] private float _ghostTransparencyMin;
    [SerializeField] private float _ghostTransparencyMax;
    [SerializeField] private float _ghostBlendMin;
    [SerializeField] private float _ghostBlendMax;
    [SerializeField] private float _ghostMatAnimDuraton;
    [SerializeField] private float _backgroundAnimDuraton;
    [SerializeField] private float _flashFadeOutDuration;
    [SerializeField] private float _flashFadeInDuration;
    [SerializeField] private float _textFadeInDuration;
    [SerializeField] private float _textFadeOutDuration;
    [SerializeField] private float _textMoveAnimDuration;


    // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
    public void InitValueSetUp(CastleRaidedTextAnimDataSO castleRaidedTextData)
    {
        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flasRectTransform = _flash.GetComponent<RectTransform>();
        _textRectTransform = _textMsg.GetComponent<RectTransform>();

        _flashImg = _flash.GetComponent<Image>();
        _backgroundImg = _background.GetComponent<Image>();

        _textTmp = _textMsg.GetComponent<TextMeshProUGUI>();

        _material = VfxEffectController.GetMaterial<Image>(_flasRectTransform.gameObject);

        // set up sprites, materials, text and other parameters values needed for animation
        _backgroundImg.sprite = castleRaidedTextData.backgroundSprite;
        _backgroundImg.color = castleRaidedTextData.backgroundColor;
        _backgroundImg.material= castleRaidedTextData.backgroundMaterial;
        _flashImg.sprite = castleRaidedTextData.flashSprite;
        _flashImg.color = castleRaidedTextData.flashColor;
        _flashImg.material = castleRaidedTextData.flashMaterial;
        _textTmp.text = castleRaidedTextData.textContent;
        _textTmp.font = castleRaidedTextData.textFont;
        _textTmp.colorGradient = castleRaidedTextData.textColor;
        _textTmp.outlineWidth = castleRaidedTextData.textOutlineWidth;
        _textTmp.outlineColor = castleRaidedTextData.textOutlineColor;

        _backgroundInitSize = castleRaidedTextData.backgroundInitSize;
        _backgroundFinalSize = castleRaidedTextData.backgroundFinalSize;
        _flashSize = castleRaidedTextData.flashSize;
        _initMsgSize  = castleRaidedTextData.initMsgSize;
        _finalMsgSize  =castleRaidedTextData.finalMsgSize;
        _ghostBoostMin = castleRaidedTextData.ghostBoostMin;
        _ghostBoostMax = castleRaidedTextData.ghostBoostMax;
        _ghostTransparencyMin  =castleRaidedTextData.ghostTransparencyMin;
        _ghostTransparencyMax  =castleRaidedTextData.ghostTransparencyMax;
        _ghostBlendMin = castleRaidedTextData.ghostBlendMin;
        _ghostBlendMax = castleRaidedTextData.ghostBlendMax;
        _ghostMatAnimDuraton  = castleRaidedTextData.ghostMatAnimDuraton;
        _backgroundAnimDuraton = castleRaidedTextData.backgroundAnimDuraton;
        _flashFadeOutDuration = castleRaidedTextData.flashFadeOutDuration;
        _flashFadeInDuration = castleRaidedTextData.flashFadeInDuration;
        _textFadeInDuration = castleRaidedTextData.textFadeInDuration;
        _textFadeOutDuration = castleRaidedTextData.textFadeOutDuration;
        _textMoveAnimDuration = castleRaidedTextData.textMoveAnimDuration;

        InitAnimeSetUp();

    }

    // This method sets up the initial position and vaules of the gameobjects
    void InitAnimeSetUp()
    {
        _backgroundRectTransform.DOAnchorPos(Vector2.zero, 0f);
        _flasRectTransform.DOAnchorPos(Vector2.zero, 0f);

        _flasRectTransform.sizeDelta = _flashSize;
        _backgroundRectTransform.sizeDelta = _backgroundInitSize;
        
        _flashImg.DOFade(0, 0);
        _textRectTransform.sizeDelta = _initMsgSize;
        _textTmp.DOFade(0, 0);
        VfxEffectController.SetCustomMatPara(_material,"_GhostColorBoost", _ghostBoostMax);
        VfxEffectController.SetCustomMatPara(_material,"_GhostBlend", _ghostBlendMin);
        VfxEffectController.SetCustomMatPara(_material,"_GhostTransparency", _ghostTransparencyMin);
    }

    public void AnimateIn()
    {
        // _flash.SetActive(true);
        // _textMsg.SetActive(true);

        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundFinalSize, _backgroundAnimDuraton));
        tweenSeq.Join(_flashImg.DOFade(1, _flashFadeInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textTmp.DOFade(1, _textFadeInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textRectTransform.DOSizeDelta(_finalMsgSize, _textMoveAnimDuration));
        tweenSeq.Join(DOVirtual.DelayedCall(.5f, () => AnimateOut()));
        _particleSys.Play();
        // AnimateOut();

    }

    // This method animates the text exiting the screen
    void AnimateOut()
    {

        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(DOVirtual.Float(_ghostBoostMax, _ghostBoostMin, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_material,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostBlendMin, _ghostBlendMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_material,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostTransparencyMin, _ghostTransparencyMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_material,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        tweenSeq.Append(_flashImg.DOFade(0, _flashFadeOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textTmp.DOFade(0, _textFadeOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundInitSize, _backgroundAnimDuraton));

        
    }
}
