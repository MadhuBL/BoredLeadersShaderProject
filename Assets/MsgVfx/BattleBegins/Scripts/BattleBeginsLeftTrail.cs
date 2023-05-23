using System;
using DG.Tweening;
using ShaderEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BattleBeginsLeftTrail : MonoBehaviour
{

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _leftMsg;
    [SerializeField] private GameObject _rightMsg;
    [SerializeField] private GameObject _rightFadetMsg;

    [SerializeField] private GameObject _leftFadeMsg;

    // [SerializeField] private GameObject glow;

    [SerializeField] private RectTransform _backgroundRectTransform;
    [SerializeField] private RectTransform _flashRectTransform;
    [SerializeField] private RectTransform _leftMsgRectTransform;
    [SerializeField] private RectTransform _leftFadeMsgRectTransform;

    [SerializeField] private RectTransform _rightMsgRectTransform;
    [SerializeField] private RectTransform _rightFadeMsgRectTransform;


    // [SerializeField] private Image backgroundImg;
    [SerializeField] private Image _flashImg;
    // // [SerializeField] private Image glowImg;


    [SerializeField] private TextMeshProUGUI _leftMsgTmp;
    [SerializeField] private TextMeshProUGUI _rightMsgTmp;
    [SerializeField] private TextMeshProUGUI _leftFadeMsgTmp;
    [SerializeField] private TextMeshProUGUI _rightFadeMsgTmp;

    // Material _material;
    [SerializeField] private float _backgroundAnimDuraton = 1f;

    // [SerializeField] private float leftMsgAlphaAnimDuration = 1f;
    // [SerializeField] private float rightMsgAlphaAnimDuration = 1f;
    [SerializeField] private float _msgAlphaAnimDuration = 1f;
    [SerializeField] private float _msgMoveAnimDuration = 1f;
    [SerializeField] private float _fadeMsgMoveDistance = 25f;
    [SerializeField] private float _fadeMsgMoveAnimDuration = 1f;
    [SerializeField] private float _fadeMsgAplhaMax = 0.4f;
    [SerializeField] private float _flashAplhaMin = 0;
    [SerializeField] private float _flashAplhaMax = .5f;
    [SerializeField] private float _flashAplhaAnimDuration = 1f;
    [SerializeField] private float _flashDieAnimDuration = 1f;
    [SerializeField] private float _textDisplayDuration = 1f;

    [SerializeField] private Vector2 _rightTextInitPos = new Vector2(450, 0);
    [SerializeField] private Vector2 _rightTextFinalPos = new Vector2(220, 0);

    [SerializeField] private Vector2 _leftTextInitPos = new Vector2(-450, 0);
    [SerializeField] private Vector2 _leftTextFinalPos = new Vector2(-220, 0);

    [SerializeField] private Vector2 _flashInitSize = new Vector2(850, 250);
    [SerializeField] private Vector2 _flashFinalSize = new Vector2(850, 50);

    [SerializeField] private Vector2 _backgroundInitSize = new Vector2(800, 0);
    [SerializeField] private Vector2 _backgroundFinalSize = new Vector2(800, 350);


    // [SerializeField] private Vector2 msgSize = new Vector2(400, 100);


    void Start()
    {
    //     // _material = VfxEffectController.GetMaterial<Image>(glow);

        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flashRectTransform = _flash.GetComponent<RectTransform>();
        _leftMsgRectTransform = _leftMsg.GetComponent<RectTransform>();
        _rightMsgRectTransform = _rightMsg.GetComponent<RectTransform>();
        _leftFadeMsgRectTransform = _leftFadeMsg.GetComponent<RectTransform>();
        _rightFadeMsgRectTransform = _rightFadetMsg.GetComponent<RectTransform>();

        // backgroundImg =  _background.GetComponent<Image>();
        _flashImg =  _flash.GetComponent<Image>();
        // glowImg =  glow.GetComponent<Image>();

        _leftMsgTmp =  _leftMsg.GetComponent<TextMeshProUGUI>();
        _rightMsgTmp = _rightMsg.GetComponent<TextMeshProUGUI>();
        _leftFadeMsgTmp = _leftFadeMsg.GetComponent<TextMeshProUGUI>();
        _rightFadeMsgTmp = _rightFadetMsg.GetComponent<TextMeshProUGUI>();


    } 

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            AnimateIn();
        }        
    }

    void AnimateIn()
    {
        _background.SetActive(true);
        _flash.SetActive(true);
        _leftMsg.SetActive(true);
        _rightMsg.SetActive(true);

        // _backgroundRectTransform.DOAnchorPos(_rightTextInitPos, 0);
        _backgroundRectTransform.sizeDelta = _backgroundInitSize;

        // _flashRectTransform.DOAnchorPos(_rightTextInitPos, 0);
        _flashRectTransform.sizeDelta = _flashInitSize;

        _leftMsgRectTransform.DOAnchorPos(_leftTextInitPos, 0);
        // _leftMsgRectTransform.sizeDelta = msgSize;
        
        _rightMsgRectTransform.DOAnchorPos(_rightTextInitPos, 0);
        // fadedMsgRectTransform.sizeDelta = msgSize;

        _leftFadeMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _rightFadeMsgRectTransform.DOAnchorPos(Vector2.zero, 0);

        // backgroundImg.DOFade(0, 0.001f);
        _flashImg.DOFade(_flashAplhaMin, 0);

        _leftMsgTmp.DOFade(0, 0);
        _rightMsgTmp.DOFade(0, 0);
        _leftFadeMsgTmp.DOFade(_fadeMsgAplhaMax, 0);
        _rightFadeMsgTmp.DOFade(_fadeMsgAplhaMax, 0);
        // glowImg.DOFade(0, 0.001f);

        float actualTextDisplayDuration = _textDisplayDuration - _flashDieAnimDuration -_fadeMsgMoveAnimDuration - _backgroundAnimDuraton;
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundFinalSize, _backgroundAnimDuraton));
        
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftMsgTmp.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftMsgRectTransform.DOAnchorPos(_leftTextFinalPos, _msgMoveAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightMsgTmp.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightMsgRectTransform.DOAnchorPos(_rightTextFinalPos, _msgMoveAnimDuration));
        
        tweenSeq.Append(_leftFadeMsgRectTransform.DOAnchorPos(Vector2.left * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration ));
        tweenSeq.Join(_rightFadeMsgRectTransform.DOAnchorPos(Vector2.right * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _flashAplhaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _leftFadeMsgTmp.DOFade(0, 0));
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _rightFadeMsgTmp.DOFade(0, 0));

        tweenSeq.Append(_flashRectTransform.DOSizeDelta(_flashFinalSize, _flashDieAnimDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMin, _flashAplhaAnimDuration));
        tweenSeq.Append(DOVirtual.DelayedCall(actualTextDisplayDuration, () => AnimeOut()));

    }

    void AnimeOut()
    {
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundInitSize, _backgroundAnimDuraton));
        tweenSeq.Join(_leftMsgTmp.DOFade(0, _msgAlphaAnimDuration/1.5f));
        tweenSeq.Join(_rightMsgTmp.DOFade(0, _msgAlphaAnimDuration/1.5f));

        _background.SetActive(true);
        _flash.SetActive(true);
        _leftMsg.SetActive(true);
        _rightMsg.SetActive(true);

    }

}