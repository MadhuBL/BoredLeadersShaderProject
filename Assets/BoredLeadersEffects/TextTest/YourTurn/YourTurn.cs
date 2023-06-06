using System;
using DG.Tweening;
using ShaderEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class YourTurn : MonoBehaviour
{

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject msg;
    [SerializeField] private GameObject fadedMsg;

    [SerializeField] private RectTransform backgroundRectTransform;
    [SerializeField] private RectTransform flashRectTransform;
    [SerializeField] private RectTransform msgRectTransform;
    [SerializeField] private RectTransform fadedMsgRectTransform;

    [SerializeField] private Image backgroundImg;
    [SerializeField] private Image flashImg;


    [SerializeField] private TextMeshProUGUI msgTmp;
    [SerializeField] private TextMeshProUGUI fadedMsgTmp;

    [SerializeField] private float flashAplhaMin = 0;
    [SerializeField] private float flashAplhaMax = 1;
    [SerializeField] private float fadeTextAplhaMax = .3f;

    [SerializeField] private float animateInDuration = .2f;
    [SerializeField] private float animateOutDuration = .2f;
    [SerializeField] private float displayTextDuration = .8f;
    [SerializeField] private float textFadeOutDuration = .4f;


    [SerializeField] private Vector2 rightPos = new Vector2(800, 0);
    [SerializeField] private Vector2 leftPos = new Vector2(-800, 0);
    [SerializeField] private Vector2 flashSize = new Vector2(500, 60);
    [SerializeField] private Vector2 backgroundSize = new Vector2(300, 80);
    [SerializeField] private Vector2 initMsgSize = new Vector2(400, 100);
    [SerializeField] private Vector2 finalMsgSize = new Vector2(600, 150);



    void Start()
    {

        backgroundRectTransform = background.GetComponent<RectTransform>();
        flashRectTransform = flash.GetComponent<RectTransform>();
        msgRectTransform = msg.GetComponent<RectTransform>();
        fadedMsgRectTransform = fadedMsg.GetComponent<RectTransform>();

        backgroundImg =  background.GetComponent<Image>();
        flashImg =  flash.GetComponent<Image>();

        msgTmp =  msg.GetComponent<TextMeshProUGUI>();
        fadedMsgTmp = fadedMsg.GetComponent<TextMeshProUGUI>();

    } 

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SlideIn();
        }        
    }

    void SlideIn()
    {
        backgroundRectTransform.DOAnchorPos(rightPos, 0);
        backgroundRectTransform.sizeDelta = backgroundSize;

        flashRectTransform.DOAnchorPos(rightPos, 0);
        flashRectTransform.sizeDelta = flashSize;

        msgRectTransform.DOAnchorPos(leftPos, 0);
        msgRectTransform.sizeDelta = initMsgSize;
        
        fadedMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
        fadedMsgRectTransform.sizeDelta = initMsgSize;

        backgroundImg.DOFade(0, 0);
        flashImg.DOFade(flashAplhaMin, 0);

        msgTmp.DOFade(0, 0);
        fadedMsgTmp.DOFade(fadeTextAplhaMax, 0);



        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(backgroundRectTransform.DOAnchorPos(Vector2.zero, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(backgroundImg.DOFade(1, animateInDuration)).SetEase(Ease.Linear);


        tweenSeq.Join(flashRectTransform.DOAnchorPos(Vector2.zero, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(flashImg.DOFade(flashAplhaMax, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(flashRectTransform.DOSizeDelta(new Vector2(flashSize.x/2f, flashSize.y), animateInDuration));

        tweenSeq.Join(msgRectTransform.DOAnchorPos(Vector2.zero, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(msgRectTransform.DOSizeDelta(finalMsgSize, animateInDuration));
        tweenSeq.Join(fadedMsgRectTransform.DOSizeDelta(finalMsgSize, animateInDuration));
        tweenSeq.Join(msgTmp.DOFade(1, animateInDuration));
        
        tweenSeq.Append(fadedMsgRectTransform.DOAnchorPos(Vector2.zero + Vector2.right * 100 , displayTextDuration + animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(fadedMsgTmp.DOFade(0, displayTextDuration + animateInDuration)).SetEase(Ease.Linear).OnComplete(() => SlideOut());

        tweenSeq.Join(flashRectTransform.DOAnchorPos(leftPos, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(flashImg.DOFade(flashAplhaMin, animateInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(flashRectTransform.DOSizeDelta(flashSize, animateInDuration));

    }

    void SlideOut()
    {
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(flashRectTransform.DOAnchorPos(rightPos, animateOutDuration * 2)).SetEase(Ease.Linear);
        tweenSeq.Join(flashRectTransform.DOSizeDelta(new Vector2(flashSize.x/2f, flashSize.y), animateOutDuration));
        tweenSeq.Join(flashImg.DOFade(flashAplhaMax, animateOutDuration)).SetEase(Ease.Linear);

        tweenSeq.Insert(0.2f, flashRectTransform.DOSizeDelta(flashSize, animateOutDuration));
        tweenSeq.Insert(0.2f, flashImg.DOFade(flashAplhaMin, animateOutDuration)).SetEase(Ease.Linear);
        
        tweenSeq.Join(backgroundRectTransform.DOAnchorPos(leftPos, animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(backgroundImg.DOFade(0, animateOutDuration)).SetEase(Ease.Linear);

        tweenSeq.Insert(animateOutDuration, msgRectTransform.DOAnchorPos(rightPos, animateOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Insert(animateOutDuration, msgRectTransform.DOSizeDelta(initMsgSize, animateOutDuration));
        tweenSeq.Insert(animateOutDuration, msgTmp.DOFade(0, textFadeOutDuration)).SetEase(Ease.Linear);

    }

}
