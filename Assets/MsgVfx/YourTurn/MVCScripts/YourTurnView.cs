using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

// By @Madhu
// This calss is the View part of the YoutTurn text animation which is responsible of the animation of the text
public class YourTurnView : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _msg;
    [SerializeField] private GameObject _fadedMsg;

    private RectTransform _backgroundRectTransform;
    private RectTransform _flashRectTransform;
    private RectTransform _msgRectTransform;
    private RectTransform _fadedMsgRectTransform;

    private Image _backgroundImg;
    private Image _flashImg;
    private TextMeshProUGUI _msgTmp;
    private TextMeshProUGUI _fadedMsgTmp;

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
    public void InitValueSetUp(YourTurnTextAnimSO yourTurnTextData)
    {

        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flashRectTransform = _flash.GetComponent<RectTransform>();
        _msgRectTransform = _msg.GetComponent<RectTransform>();
        _fadedMsgRectTransform = _fadedMsg.GetComponent<RectTransform>();

        _backgroundImg =  _background.GetComponent<Image>();
        _flashImg =  _flash.GetComponent<Image>();

        _msgTmp =  _msg.GetComponent<TextMeshProUGUI>();
        _fadedMsgTmp = _fadedMsg.GetComponent<TextMeshProUGUI>();

        // set up sprites, materials, text and other parameters values needed for animation

        _flashImg.sprite = yourTurnTextData.flashSprite;
        _backgroundImg.sprite = yourTurnTextData.backgroundSprite;
        _backgroundImg.color = yourTurnTextData.backgroundColor;
        _flashImg.color = yourTurnTextData.flashColor;
        _backgroundImg.material = yourTurnTextData.backgroundMaterial;
        _flashImg.material = yourTurnTextData.flashMaterial;
        _msgTmp.text = yourTurnTextData.mainTextContent;
        _fadedMsgTmp.text = yourTurnTextData.fadeTextContent;
        _fadedMsgTmp.font = yourTurnTextData.fadeTextFont;
        _msgTmp.font = yourTurnTextData.mainTextFont;
        _msgTmp.colorGradient = yourTurnTextData.mainTextColor;
        _fadedMsgTmp.colorGradient = yourTurnTextData.fadeTextColor;
        _msgTmp.outlineWidth = yourTurnTextData.mainTextOutlineWidth;
        _fadedMsgTmp.outlineWidth = yourTurnTextData.fadeTextOutlineWidth;
        _msgTmp.outlineColor = yourTurnTextData.mainTextOutlineColor;
        _fadedMsgTmp.outlineColor = yourTurnTextData.fadeTextOutlineColor;

        _flashAplhaMin = yourTurnTextData.flashAplhaMin;
        _flashAplhaMax = yourTurnTextData.flashAplhaMax;
        _fadeTextAplhaMax = yourTurnTextData.fadeTextAplhaMax;
        _animateInDuration = yourTurnTextData.animateInDuration;
        _animateOutDuration = yourTurnTextData.animateOutDuration;
        _displayTextDuration = yourTurnTextData.displayTextDuration;
        _textFadeOutDuration = yourTurnTextData.textFadeOutDuration;
        _rightPos = yourTurnTextData.rightPos;
        _leftPos = yourTurnTextData.leftPos;
        _flashSize = yourTurnTextData.flashSize;
        _backgroundSize = yourTurnTextData.backgroundSize;
        _initMsgSize = yourTurnTextData.initMsgSize;
        _finalMsgSize = yourTurnTextData.finalMsgSize;

        InitAnimeSetUp();

    } 

    void InitAnimeSetUp()
    {
        _backgroundRectTransform.DOAnchorPos(_rightPos, 0);
        _backgroundRectTransform.sizeDelta = _backgroundSize;
        _flashRectTransform.DOAnchorPos(_rightPos, 0);
        _flashRectTransform.sizeDelta = _flashSize;
        _msgRectTransform.DOAnchorPos(_leftPos, 0);
        _msgRectTransform.sizeDelta = _initMsgSize;
        _fadedMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _fadedMsgRectTransform.sizeDelta = _initMsgSize;
        _backgroundImg.DOFade(0, 0);
        _flashImg.DOFade(_flashAplhaMin, 0);
        _msgTmp.DOFade(0, 0);
        _fadedMsgTmp.DOFade(_fadeTextAplhaMax, 0);
    }

    public void AnimateIn()
    {

        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundImg.DOFade(1, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateInDuration));
        tweenSeq.Join(_msgRectTransform.DOAnchorPos(Vector2.zero, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_msgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
        tweenSeq.Join(_fadedMsgRectTransform.DOSizeDelta(_finalMsgSize, _animateInDuration));
        tweenSeq.Join(_msgTmp.DOFade(1, _animateInDuration));
        tweenSeq.Append(_fadedMsgRectTransform.DOAnchorPos(Vector2.zero + Vector2.right * 100 , _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_fadedMsgTmp.DOFade(0, _displayTextDuration + _animateInDuration)).SetEase(Ease.Linear).OnComplete(() => AnimateOut());
        tweenSeq.Join(_flashRectTransform.DOAnchorPos(_leftPos, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMin, _animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(_flashSize, _animateInDuration));

    }

    void AnimateOut()
    {
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_flashRectTransform.DOAnchorPos(_rightPos, _animateOutDuration * 2)).SetEase(Ease.Linear);
        tweenSeq.Join(_flashRectTransform.DOSizeDelta(new Vector2(_flashSize.x/2f, _flashSize.y), _animateOutDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(0.2f, _flashRectTransform.DOSizeDelta(_flashSize, _animateOutDuration));
        tweenSeq.Insert(0.2f, _flashImg.DOFade(_flashAplhaMin, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundRectTransform.DOAnchorPos(_leftPos, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundImg.DOFade(0, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(_animateOutDuration, _msgRectTransform.DOAnchorPos(_rightPos, _animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(_animateOutDuration, _msgRectTransform.DOSizeDelta(_initMsgSize, _animateOutDuration));
        tweenSeq.Insert(_animateOutDuration, _msgTmp.DOFade(0, _textFadeOutDuration)).SetEase(Ease.Linear);

    }
}
