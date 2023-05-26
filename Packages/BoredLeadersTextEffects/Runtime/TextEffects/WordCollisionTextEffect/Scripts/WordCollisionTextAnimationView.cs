using System;
using DG.Tweening;
using ShaderEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

// By @Madhu
// This calss is the View part of the BattleBegin text animation which is responsible of the animation of the text
public class WordCollisionTextAnimationView : MonoBehaviour
{

    // GameObjects
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _rightTextImgObj;
    [SerializeField] private GameObject _rightFadeTextImgObj;
    [SerializeField] private GameObject _leftTextImgObj;
    [SerializeField] private GameObject _leftFadeTextImgObj;

    // GameObject Components
    private RectTransform _backgroundRectTransform;                         
    private RectTransform _flashRectTransform;
    public RectTransform _rightTextImgRectTransform;
    public RectTransform _rightFadeTextImgRectTransform;
    public RectTransform _leftTextImgRectTransform;
    public RectTransform _leftFadeTextImgRectTransform;
    private Image _backgroundImg;                           
    private Image _flashImg;
    public Image _rightTextImg;
    public Image _rightFadeTextImg;
    public Image _leftTextImg;
    public Image _leftFadeTextImg;

    //Animation Parameters 
    [SerializeField] private float _backgroundAnimDuraton;
    [SerializeField] private float _msgAlphaAnimDuration;
    [SerializeField] private float _msgMoveAnimDuration;
    [SerializeField] private float _fadeMsgMoveDistance ;
    [SerializeField] private float _fadeMsgMoveAnimDuration;
    [SerializeField] private float _fadeMsgAplhaMax;
    [SerializeField] private float _flashAplhaMin;
    [SerializeField] private float _flashAplhaMax ;
    [SerializeField] private float _flashAplhaAnimDuration;
    [SerializeField] private float _flashDieAnimDuration;
    [SerializeField] private float _textDisplayDuration;
    [SerializeField] private Vector2 _rightTextSize;
    [SerializeField] private Vector2 _leftTextSize;

    [SerializeField] private Vector2 _rightTextInitPos;
    [SerializeField] private Vector2 _rightTextFinalPos;
    [SerializeField] private Vector2 _leftTextInitPos;
    [SerializeField] private Vector2 _leftTextFinalPos;
    [SerializeField] private Vector2 _flashInitSize;
    [SerializeField] private Vector2 _flashFinalSize;
    [SerializeField] private Vector2 _backgroundInitSize;
    [SerializeField] private Vector2 _backgroundFinalSize;

    [SerializeField] private float _ghostBoostMin;
    [SerializeField] private float _ghostBoostMax;
    [SerializeField] private float _ghostTransparencyMin;
    [SerializeField] private float _ghostTransparencyMax;
    [SerializeField] private float _ghostBlendMin;
    [SerializeField] private float _ghostBlendMax;
    [SerializeField] private float _ghostMatAnimDuraton;
    private Material _flashMaterial;
    public Material _leftMaterial;
    public Material _rightMaterial;


    



    // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
    public void InitValueSetUp(WordCollisionTextAnimationDataSO wordCollisionData)
    {   
        // Activate gameobjects
        // _background.SetActive(true);
        // _flash.SetActive(true);
        // _leftMsg.SetActive(true);
        // _rightMsg.SetActive(true);

        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flashRectTransform = _flash.GetComponent<RectTransform>();
        _rightTextImgRectTransform = _rightTextImgObj.GetComponent<RectTransform>();
        _leftTextImgRectTransform = _leftTextImgObj.GetComponent<RectTransform>();
        _rightFadeTextImgRectTransform = _rightFadeTextImgObj.GetComponent<RectTransform>();
        _leftFadeTextImgRectTransform = _leftFadeTextImgObj.GetComponent<RectTransform>();

        _backgroundImg =  _background.GetComponent<Image>();
        _flashImg =  _flash.GetComponent<Image>();
        _rightTextImg =  _rightTextImgObj.GetComponent<Image>();
        _rightFadeTextImg =  _rightFadeTextImgObj.GetComponent<Image>();
        _leftTextImg =  _leftTextImgObj.GetComponent<Image>();
        _leftFadeTextImg =  _leftFadeTextImgObj.GetComponent<Image>();


        _flashMaterial = wordCollisionData.flashMaterial;


        // set up sprites, materials, text and other parameters values needed for animation
        _backgroundImg.sprite =  wordCollisionData.backgroundSprite;
        _flashImg.sprite = wordCollisionData.flashSprite;
        _rightTextImg.sprite = wordCollisionData.rightTextImgSprite;
        _rightFadeTextImg.sprite = wordCollisionData.rightTextImgSprite;
        _leftTextImg.sprite = wordCollisionData.leftTextImgSprite;
        _leftFadeTextImg.sprite = wordCollisionData.leftTextImgSprite;

        _backgroundImg.material = wordCollisionData.backgroundMaterial;
        _flashImg.material = wordCollisionData.flashMaterial;
        _rightTextImg.material = wordCollisionData.rightTextImgMaterial;
        _rightFadeTextImg.material = wordCollisionData.rightTextImgMaterial;
        _leftTextImg.material = wordCollisionData.leftTextImgMaterial;
        _leftFadeTextImg.material = wordCollisionData.leftTextImgMaterial;

        _flashMaterial = _flashImg.material;
        _leftMaterial = _leftTextImg.material;
        _rightMaterial = _rightTextImg.material;
        
        _rightTextSize = wordCollisionData.rightTextSize;
        _leftTextSize = wordCollisionData.leftTextSize;
        _backgroundAnimDuraton  = wordCollisionData.backgroundAnimDuraton ;
        _msgAlphaAnimDuration = wordCollisionData.msgAlphaAnimDuration;
        _msgMoveAnimDuration = wordCollisionData.msgMoveAnimDuration;
        _fadeMsgMoveDistance = wordCollisionData.fadeMsgMoveDistance;
        _fadeMsgMoveAnimDuration = wordCollisionData.fadeMsgMoveAnimDuration;
        _fadeMsgAplhaMax = wordCollisionData.fadeMsgAplhaMax;
        _flashAplhaMin = wordCollisionData.flashAplhaMin;
        _flashAplhaMax = wordCollisionData.flashAplhaMax;
        _flashAplhaAnimDuration = wordCollisionData.flashAplhaAnimDuration;
        _flashDieAnimDuration = wordCollisionData.flashDieAnimDuration;
        _textDisplayDuration = wordCollisionData.textDisplayDuration;
        _rightTextInitPos = wordCollisionData.rightTextInitPos;
        _rightTextFinalPos = wordCollisionData.rightTextFinalPos;
        _leftTextInitPos = wordCollisionData.leftTextInitPos;
        _leftTextFinalPos = wordCollisionData.leftTextFinalPos;
        _flashInitSize = wordCollisionData.flashInitSize;
        _flashFinalSize = wordCollisionData.flashFinalSize;
        _backgroundInitSize = wordCollisionData.backgroundInitSize;
        _backgroundFinalSize = wordCollisionData.backgroundFinalSize;
        _ghostBoostMin = wordCollisionData.ghostBoostMin;
        _ghostBoostMax = wordCollisionData.ghostBoostMax;
        _ghostTransparencyMin  =wordCollisionData.ghostTransparencyMin;
        _ghostTransparencyMax  =wordCollisionData.ghostTransparencyMax;
        _ghostBlendMin = wordCollisionData.ghostBlendMin;
        _ghostBlendMax = wordCollisionData.ghostBlendMax;
        _ghostMatAnimDuraton  = wordCollisionData.ghostMatAnimDuraton;


        InitAnimeSetUp();

    }

    // This method sets up the initial position and vaules of the gameobjects
    void InitAnimeSetUp()
    {
        _backgroundRectTransform.sizeDelta = _backgroundInitSize;
        _flashRectTransform.DOSizeDelta(_flashInitSize, 0);
        _leftTextImgRectTransform.sizeDelta = _leftTextSize;
        _leftFadeTextImgRectTransform.sizeDelta = _leftTextSize;
        _rightTextImgRectTransform.sizeDelta = _rightTextSize;
        _rightFadeTextImgRectTransform.sizeDelta = _rightTextSize;


        _leftTextImgRectTransform.DOAnchorPos(_leftTextInitPos, 0);
        _rightTextImgRectTransform.DOAnchorPos(_rightTextInitPos, 0);
        _leftFadeTextImgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _rightFadeTextImgRectTransform.DOAnchorPos(Vector2.zero, 0);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostColorBoost", _ghostBoostMax);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostBlend", _ghostBlendMin);
        VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostTransparency", _ghostTransparencyMin);
        _flashImg.DOFade(_flashAplhaMin, 0);
        _leftTextImg.DOFade(0, 0);
        _rightTextImg.DOFade(0, 0);
        _leftFadeTextImg.DOFade(_fadeMsgAplhaMax, 0);
        _rightFadeTextImg.DOFade(_fadeMsgAplhaMax, 0);

    }
    
    // This method animates the text entering the screen
    public void AnimateIn()
    {

        float actualTextDisplayDuration = _textDisplayDuration - _fadeMsgMoveAnimDuration - _backgroundAnimDuraton;
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundFinalSize, _backgroundAnimDuraton));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftTextImg.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftTextImgRectTransform.DOAnchorPos(_leftTextFinalPos, _msgMoveAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightTextImg.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightTextImgRectTransform.DOAnchorPos(_rightTextFinalPos, _msgMoveAnimDuration));
        tweenSeq.Append(_leftFadeTextImgRectTransform.DOAnchorPos(Vector2.left * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration ));
        tweenSeq.Join(_rightFadeTextImgRectTransform.DOAnchorPos(Vector2.right * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _flashAplhaAnimDuration));
        tweenSeq.Join(DOVirtual.Float(0, 1, _fadeMsgMoveAnimDuration, v => {VfxEffectController.SetCustomMatPara(_leftMaterial, "_ShineLocation",v); } )).SetEase(Ease.Linear);
        tweenSeq.Insert(_fadeMsgMoveAnimDuration, DOVirtual.Float(0, 1, _fadeMsgMoveAnimDuration, v => {VfxEffectController.SetCustomMatPara(_rightMaterial, "_ShineLocation",v); } )).SetEase(Ease.Linear);
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _leftFadeTextImg.DOFade(0, 0));
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _rightFadeTextImg.DOFade(0, 0));
        tweenSeq.Append(DOVirtual.DelayedCall(actualTextDisplayDuration, () => AnimeOut()));

    }

    // This method animates the text exiting the screen
    void AnimeOut()
    {
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(DOVirtual.Float(_ghostBoostMax, _ghostBoostMin, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostBlendMin, _ghostBlendMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostTransparencyMin, _ghostTransparencyMax, _ghostMatAnimDuraton, v => {VfxEffectController.SetCustomMatPara(_flashMaterial,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        tweenSeq.Append( _flashImg.DOFade(_flashAplhaMin, .3f));
        tweenSeq.Insert(_flashDieAnimDuration, _backgroundRectTransform.DOSizeDelta(_backgroundInitSize, _backgroundAnimDuraton));
        tweenSeq.Insert(_flashDieAnimDuration, _leftTextImg.DOFade(0, _msgAlphaAnimDuration/1.5f));
        tweenSeq.Insert(_flashDieAnimDuration, _rightTextImg.DOFade(0, _msgAlphaAnimDuration/1.5f));

    }
}