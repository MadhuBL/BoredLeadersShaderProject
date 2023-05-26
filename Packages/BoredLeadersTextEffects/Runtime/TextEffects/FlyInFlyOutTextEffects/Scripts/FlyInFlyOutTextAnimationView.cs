// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using DG.Tweening;

// // By @Madhu
// // This calss is the View part of the YoutTurn text animation which is responsible of the animation of the text
// public class YourTurnView : MonoBehaviour
// {
//     [SerializeField] private GameObject _background;
//     [SerializeField] private GameObject _flash;
//     [SerializeField] private GameObject _msg;
//     [SerializeField] private GameObject _fadedMsg;

//     private RectTransform _backgroundRectTransform;
//     private RectTransform _flashRectTransform;
//     private RectTransform _msgRectTransform;
//     private RectTransform _fadedMsgRectTransform;

//     private Image _backgroundImg;
//     private Image _flashImg;
//     private TextMeshProUGUI _msgTmp;
//     private TextMeshProUGUI _fadedMsgTmp;

//     //Animation Parameters 
//     [SerializeField] private float _flashAplhaMin;
//     [SerializeField] private float _flashAplhaMax;
//     [SerializeField] private float _fadeTextAplhaMax;
//     [SerializeField] private float _animateInDuration;
//     [SerializeField] private float _animateOutDuration;
//     [SerializeField] private float _displayTextDuration;
//     [SerializeField] private float _textFadeOutDuration;

//     [SerializeField] private Vector2 _rightPos;
//     [SerializeField] private Vector2 _leftPos;
//     [SerializeField] private Vector2 _flashSize;
//     [SerializeField] private Vector2 _backgroundSize;
//     [SerializeField] private Vector2 _initMsgSize;
//     [SerializeField] private Vector2 _finalMsgSize;
    
//     // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
//     public void InitValueSetUp(YourTurnTextAnimSO flyInFlyOutData)
//     {

//         _backgroundRectTransform = _background.GetComponent<RectTransform>();
//         _flashRectTransform = _flash.GetComponent<RectTransform>();
//         _msgRectTransform = _msg.GetComponent<RectTransform>();
//         _fadedMsgRectTransform = _fadedMsg.GetComponent<RectTransform>();

//         _backgroundImg =  _background.GetComponent<Image>();
//         _flashImg =  _flash.GetComponent<Image>();

//         _msgTmp =  _msg.GetComponent<TextMeshProUGUI>();
//         _fadedMsgTmp = _fadedMsg.GetComponent<TextMeshProUGUI>();

//         // set up sprites, materials, text and other parameters values needed for animation

//         _flashImg.sprite = flyInFlyOutData.flashSprite;
//         _backgroundImg.sprite = flyInFlyOutData.backgroundSprite;
//         _backgroundImg.color = flyInFlyOutData.backgroundColor;
//         _flashImg.color = flyInFlyOutData.flashColor;
//         _backgroundImg.material = flyInFlyOutData.backgroundMaterial;
//         _flashImg.material = flyInFlyOutData.flashMaterial;
//         _msgTmp.text = flyInFlyOutData.mainTextContent;
//         _fadedMsgTmp.text = flyInFlyOutData.fadeTextContent;
//         _fadedMsgTmp.font = flyInFlyOutData.fadeTextFont;
//         _msgTmp.font = flyInFlyOutData.mainTextFont;
//         _msgTmp.colorGradient = flyInFlyOutData.mainTextColor;
//         _fadedMsgTmp.colorGradient = flyInFlyOutData.fadeTextColor;
//         _msgTmp.outlineWidth = flyInFlyOutData.mainTextOutlineWidth;
//         _fadedMsgTmp.outlineWidth = flyInFlyOutData.fadeTextOutlineWidth;
//         _msgTmp.outlineColor = flyInFlyOutData.mainTextOutlineColor;
//         _fadedMsgTmp.outlineColor = flyInFlyOutData.fadeTextOutlineColor;

//         _flashAplhaMin = flyInFlyOutData.flashAplhaMin;
//         _flashAplhaMax = flyInFlyOutData.flashAplhaMax;
//         _fadeTextAplhaMax = flyInFlyOutData.fadeTextAplhaMax;
//         _animateInDuration = flyInFlyOutData.animateInDuration;
//         _animateOutDuration = flyInFlyOutData.animateOutDuration;
//         _displayTextDuration = flyInFlyOutData.displayTextDuration;
//         _textFadeOutDuration = flyInFlyOutData.textFadeOutDuration;
//         _rightPos = flyInFlyOutData.rightPos;
//         _leftPos = flyInFlyOutData.leftPos;
//         _flashSize = flyInFlyOutData.flashSize;
//         _backgroundSize = flyInFlyOutData.backgroundSize;
//         _initMsgSize = flyInFlyOutData.initMsgSize;
//         _finalMsgSize = flyInFlyOutData.finalMsgSize;

//         InitAnimeSetUp();

//     } 

//     // This method sets up the initial position and vaules of the gameobjects
//     void InitAnimeSetUp()
//     {
//         _backgroundRectTransform.DOAnchorPos(_rightPos, 0);
//         _backgroundRectTransform.sizeDelta = _backgroundSize;
//         _flashRectTransform.DOAnchorPos(_rightPos, 0);
//         _flashRectTransform.sizeDelta = _flashSize;
//         _msgRectTransform.DOAnchorPos(_leftPos, 0);
//         _msgRectTransform.sizeDelta = _initMsgSize;
//         _fadedMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
//         _fadedMsgRectTransform.sizeDelta = _initMsgSize;
//         _backgroundImg.DOFade(0, 0);
//         _flashImg.DOFade(_flashAplhaMin, 0);
//         _msgTmp.DOFade(0, 0);
//         _fadedMsgTmp.DOFade(_fadeTextAplhaMax, 0);
//     }

//     // This method animates the text entering the screen
//     public void AnimateIn()
//     {

//         Sequence tweenSeq = DOTween.Sequence();

//         tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_backgroundImg.DOFade(1, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateInDuration));
//         tweenSeq.Join(_msgRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_msgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
//         tweenSeq.Join(_fadedMsgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
//         tweenSeq.Join(_msgTmp.DOFade(1, _animateInDuration));
//         tweenSeq.Append(_fadedMsgRectTransform.DOAnchorPos(Vector2.zero + Vector2.right * 100 , _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_fadedMsgTmp.DOFade(0, _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear).OnComplete(() => AnimateOut());
//         tweenSeq.Join(_flashRectTransform.DOAnchorPos(_leftPos, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashImg.DOFade(_flashAplhaMin, _animateInDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashRectTransform.DOSizeDelta(_flashSize, _animateInDuration));

//     }

//     // This method animates the text exiting the screen
//     void AnimateOut()
//     {
//         Sequence tweenSeq = DOTween.Sequence();

//         tweenSeq.Join(_flashRectTransform.DOAnchorPos(_rightPos, _animateOutDuration * 2)).SetEase(Ease.Linear);
//         tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateOutDuration));
//         tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateOutDuration)).SetEase(Ease.Linear);
//         tweenSeq.Insert(0.2f, _flashRectTransform.DOSizeDelta(_flashSize, _animateOutDuration));
//         tweenSeq.Insert(0.2f, _flashImg.DOFade(_flashAplhaMin, _animateOutDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(_leftPos, _animateOutDuration)).SetEase(Ease.Linear);
//         tweenSeq.Join(_backgroundImg.DOFade(0, _animateOutDuration)).SetEase(Ease.Linear);
//         tweenSeq.Insert(_animateOutDuration, _msgRectTransform.DOAnchorPos(_rightPos, _animateOutDuration)).SetEase(Ease.Linear);
//         tweenSeq.Insert(_animateOutDuration, _msgRectTransform.DOSizeDelta(_initMsgSize, _animateOutDuration));
//         tweenSeq.Insert(_animateOutDuration, _msgTmp.DOFade(0, _textFadeOutDuration)).SetEase(Ease.Linear);

//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using ShaderEffects;

// By @Madhu
// This calss is the View part of the YoutTurn text animation which is responsible of the animation of the text
public class FlyInFlyOutTextAnimationView : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
     [SerializeField] private GameObject _textImgObj;
    [SerializeField] private GameObject _fadeTextImgObj;

    private RectTransform _backgroundRectTransform;
    private RectTransform _flashRectTransform;
    public RectTransform _textImgRectTransform;
    public RectTransform _fadeTextImgRectTransform;

    private Image _backgroundImg;
    private Image _flashImg;
    private Image _fadeTextImg;
    private Image _textImg;

    //Animation Parameters 
    [SerializeField] private float _flashAplhaMin;
    [SerializeField] private float _flashAplhaMax;
    [SerializeField] private float _fadeTextAplhaMax;
    [SerializeField] private float _animateInDuration;
    [SerializeField] private float _animateOutDuration;
    [SerializeField] private float _displayTextDuration;
    [SerializeField] private float _textFadeOutDuration;

    [SerializeField] private Vector2 _rightPos;
    [SerializeField] private Vector2 _leftPos;
    [SerializeField] private Vector2 _flashSize;
    [SerializeField] private Vector2 _backgroundSize;
    [SerializeField] private Vector2 _initMsgSize;
    [SerializeField] private Vector2 _finalMsgSize;
    
    // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
    public void InitValueSetUp(FlyInFlyOutTextAnimationDataSO flyInFlyOutData)
    {

        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flashRectTransform = _flash.GetComponent<RectTransform>();
        _textImgRectTransform = _textImgObj.GetComponent<RectTransform>();
        _fadeTextImgRectTransform = _fadeTextImgObj.GetComponent<RectTransform>();

        _backgroundImg =  _background.GetComponent<Image>();
        _flashImg =  _flash.GetComponent<Image>();
        _textImg = _textImgObj.GetComponent<Image>();
        _fadeTextImg = _fadeTextImgObj.GetComponent<Image>();

        // set up sprites, materials, text and other parameters values needed for animation
        _flashImg.sprite = flyInFlyOutData.flashSprite;
        _backgroundImg.sprite = flyInFlyOutData.backgroundSprite;
        _textImg.sprite = flyInFlyOutData.textImageSprite;
        _fadeTextImg.sprite = flyInFlyOutData.textImageSprite;


        _backgroundImg.color = flyInFlyOutData.backgroundColor;
        _flashImg.color = flyInFlyOutData.flashColor;
        _backgroundImg.material = flyInFlyOutData.backgroundMaterial;
        _flashImg.material = flyInFlyOutData.flashMaterial;
        _fadeTextImg.material = flyInFlyOutData.textImageMaterial;
        _textImg.material = flyInFlyOutData.textImageMaterial;
        

  
        _flashAplhaMin = flyInFlyOutData.flashAplhaMin;
        _flashAplhaMax = flyInFlyOutData.flashAplhaMax;
        _fadeTextAplhaMax = flyInFlyOutData.fadeTextAplhaMax;
        _animateInDuration = flyInFlyOutData.animateInDuration;
        _animateOutDuration = flyInFlyOutData.animateOutDuration;
        _displayTextDuration = flyInFlyOutData.displayTextDuration;
        _textFadeOutDuration = flyInFlyOutData.textFadeOutDuration;
        _rightPos = flyInFlyOutData.rightPos;
        _leftPos = flyInFlyOutData.leftPos;
        _flashSize = flyInFlyOutData.flashSize;
        _backgroundSize = flyInFlyOutData.backgroundSize;
        _initMsgSize = flyInFlyOutData.initMsgSize;
        _finalMsgSize = flyInFlyOutData.finalMsgSize;

        InitAnimeSetUp();

    } 

    // This method sets up the initial position and vaules of the gameobjects
    void InitAnimeSetUp()
    {
        _backgroundRectTransform.DOAnchorPos(_rightPos, 0);
        _backgroundRectTransform.sizeDelta = _backgroundSize;
        _flashRectTransform.DOAnchorPos(_rightPos, 0);
        _flashRectTransform.sizeDelta = _flashSize;
        _textImgRectTransform.DOAnchorPos(_leftPos, 0);
        _textImgRectTransform.sizeDelta = _initMsgSize;
        _fadeTextImgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _fadeTextImgRectTransform.sizeDelta = _initMsgSize;
        _backgroundImg.DOFade(0, 0);
        _flashImg.DOFade(_flashAplhaMin, 0);
        _textImg.DOFade(0, 0);
        _fadeTextImg.DOFade(_fadeTextAplhaMax, 0);
    }

    // This method animates the text entering the screen
    public void AnimateIn()
    {
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundImg.DOFade(1, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateInDuration));
        tweenSeq.Join(_textImgRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textImgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
        tweenSeq.Join(_fadeTextImgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
        tweenSeq.Join(_textImg.DOFade(1, _animateInDuration));
        tweenSeq.Append(_fadeTextImgRectTransform.DOAnchorPos(Vector2.zero + Vector2.right * 100 , _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_fadeTextImg.DOFade(0, _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear).OnComplete(() => AnimateOut());
        tweenSeq.Join(_flashRectTransform.DOAnchorPos(_leftPos, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMin, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(_flashSize, _animateInDuration));

    }

    // This method animates the text exiting the screen
    void AnimateOut()
    {
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_flashRectTransform.DOAnchorPos(_rightPos, _animateOutDuration * 2)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateOutDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateOutDuration *2)).SetEase(Ease.Linear);
        tweenSeq.Insert(0.1f, _flashRectTransform.DOSizeDelta(_flashSize, _animateOutDuration));
        tweenSeq.Insert(0.1f, _flashImg.DOFade(_flashAplhaMin, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(_leftPos, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundImg.DOFade(0, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(_animateOutDuration, _textImgRectTransform.DOAnchorPos(_rightPos, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(_animateOutDuration, _textImgRectTransform.DOSizeDelta(_initMsgSize, _animateOutDuration));
        tweenSeq.Insert(_animateOutDuration, _textImg.DOFade(0, _textFadeOutDuration)).SetEase(Ease.Linear);

    }
}
