
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using ShaderEffects;

// By @Madhu
// This calss is the View part of the CastleRaided text animation which is responsible of the animation of the text
public class StompEffectTextAnimationView : MonoBehaviour
{

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _textMsg;
    [SerializeField] private ParticleSystem _particleSys;
    private RectTransform _backgroundRectTransform;
    private RectTransform _flasRectTransform;
    public RectTransform _textImgRectTransform;
    private Image _flashImg;
    private Image _backgroundImg;
    public Image _textImg;

    private Material _flashMaterial;
    private Material _textImgMaterial;
    
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

    public GameObject _textImgObj;



    // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
    public void InitValueSetUp(StompEffectTextAnimationDataSO stompEffectData)
    {
        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flasRectTransform = _flash.GetComponent<RectTransform>();
        _textImgRectTransform = _textImgObj.GetComponent<RectTransform>();

        _flashImg = _flash.GetComponent<Image>();
        _backgroundImg = _background.GetComponent<Image>();
        _textImg = _textImgObj.GetComponent<Image>();

        _flashMaterial = stompEffectData.flashMaterial;
        _textImgMaterial = stompEffectData.textImgMaterial;

        // set up sprites, materials, text and other parameters values needed for animation
        _backgroundImg.sprite = stompEffectData.backgroundSprite;
        _backgroundImg.color = stompEffectData.backgroundColor;
        _backgroundImg.material= stompEffectData.backgroundMaterial;
        _flashImg.sprite = stompEffectData.flashSprite;
        _textImg.sprite = stompEffectData.textImgSprite;
        _flashImg.color = stompEffectData.flashColor;
        _flashImg.material = stompEffectData.flashMaterial;
        _textImg.material = stompEffectData.textImgMaterial;
        _flashMaterial = _flashImg.material;
        _textImgMaterial = _textImg.material;

        _backgroundInitSize = stompEffectData.backgroundInitSize;
        _backgroundFinalSize = stompEffectData.backgroundFinalSize;
        _flashSize = stompEffectData.flashSize;
        _initMsgSize  = stompEffectData.initMsgSize;
        _finalMsgSize  =stompEffectData.finalMsgSize;
        _ghostBoostMin = stompEffectData.ghostBoostMin;
        _ghostBoostMax = stompEffectData.ghostBoostMax;
        _ghostTransparencyMin  =stompEffectData.ghostTransparencyMin;
        _ghostTransparencyMax  =stompEffectData.ghostTransparencyMax;
        _ghostBlendMin = stompEffectData.ghostBlendMin;
        _ghostBlendMax = stompEffectData.ghostBlendMax;
        _ghostMatAnimDuraton  = stompEffectData.ghostMatAnimDuraton;
        _backgroundAnimDuraton = stompEffectData.backgroundAnimDuraton;
        _flashFadeOutDuration = stompEffectData.flashFadeOutDuration;
        _flashFadeInDuration = stompEffectData.flashFadeInDuration;
        _textFadeInDuration = stompEffectData.textFadeInDuration;
        _textFadeOutDuration = stompEffectData.textFadeOutDuration;
        _textMoveAnimDuration = stompEffectData.textMoveAnimDuration;

        InitAnimeSetUp();

    }

    // This method sets up the initial position and vaules of the gameobjects
    void InitAnimeSetUp()
    {
        _backgroundRectTransform.DOAnchorPos(Vector2.zero, 0f);
        _flasRectTransform.DOAnchorPos(Vector2.zero, 0f);

        _flasRectTransform.sizeDelta = _flashSize;
        _backgroundRectTransform.sizeDelta = _backgroundFinalSize;
        
        // _backgroundImg.DOFade(0, 0);
        _flashImg.DOFade(0, 0);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostColorBoost", _ghostBoostMax);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostBlend", _ghostBlendMin);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostTransparency", _ghostTransparencyMin);

        VfxEffectController.SetCustomMatPara(_textImgMaterial,"_Alpha", 0);
        _textImgRectTransform.DOSizeDelta(_initMsgSize, 0);

    }

    public void AnimateIn()
    {
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(_backgroundImg.DOFade(1, _backgroundAnimDuraton));
        tweenSeq.Join(DOVirtual.Float(0, 1, _textFadeInDuration, v => {VfxEffectController.SetCustomMatPara(_textImgMaterial, "_Alpha",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(_textImgRectTransform.DOSizeDelta(_finalMsgSize, _textMoveAnimDuration));
        tweenSeq.Insert(0.35f, _flashImg.DOFade(1, _flashFadeInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(0, 1, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_textImgMaterial, "_ShineLocation",v); } )).SetEase(Ease.Linear);
        tweenSeq.Insert(0.35f, DOVirtual.DelayedCall(.5f, () => AnimateOut()));
        _particleSys.Play();

    }

    // This method animates the text exiting the screen
    void AnimateOut()
    {

        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(DOVirtual.Float(_ghostBoostMax, _ghostBoostMin, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostBlendMin, _ghostBlendMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostTransparencyMin, _ghostTransparencyMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        tweenSeq.Append(_flashImg.DOFade(0, _flashFadeOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(_ghostMatAnimDuraton - _textFadeOutDuration, DOVirtual.Float(1, 0, _textFadeOutDuration, v => {VfxEffectController.SetCustomMatPara(_textImgMaterial, "_Alpha",v); } )).SetEase(Ease.Linear);
        tweenSeq.Insert(_ghostMatAnimDuraton - _textFadeOutDuration, _backgroundRectTransform.DOSizeDelta(_backgroundInitSize, _backgroundAnimDuraton));
        
    }
}
