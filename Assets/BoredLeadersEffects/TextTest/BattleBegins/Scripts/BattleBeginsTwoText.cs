using System;
using DG.Tweening;
using ShaderEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BattleBeginsTwoText : MonoBehaviour
{

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject topMsg;
    [SerializeField] private GameObject bottomMsg;
    // [SerializeField] private GameObject glow;

    [SerializeField] private RectTransform backgroundRectTransform;
    [SerializeField] private RectTransform flashRectTransform;
    [SerializeField] private RectTransform topMsgRectTransform;
    [SerializeField] private RectTransform bottomMsgRectTransform;

    // [SerializeField] private Image backgroundImg;
    [SerializeField] private Image flashImg;
    // // [SerializeField] private Image glowImg;


    [SerializeField] private TextMeshProUGUI topMsgTmp;
    [SerializeField] private TextMeshProUGUI bottomMsgTmp;

    // Material _material;
    [SerializeField] private float backgroundAnimDuraton = 1f;

    [SerializeField] private float topMsgAlphaAnimDuration = 1f;
    [SerializeField] private float bottomMsgAlphaAnimDuration = 1f;
    [SerializeField] private float topMsgMoveAnimDuration = 1f;
    [SerializeField] private float bottomMsgMoveAnimDuration = 1f;


    [SerializeField] private float flashAplhaMin = 0;
    [SerializeField] private float flashAplhaMax = .5f;
    [SerializeField] private float flashAplhaAnimDuration = 1f;
    [SerializeField] private float flashDieAnimDuration = 1f;

    [SerializeField] private float textDisplayDuration = 1f;



    // [SerializeField] private float textDisplayDuration = .8f;
    [SerializeField] private Vector2 bottomTextInitPos = new Vector2(350, -50);
    [SerializeField] private Vector2 bottomTextFinalPos = new Vector2(0, -50);

    [SerializeField] private Vector2 topTextIniPos = new Vector2(-350, 50);
    [SerializeField] private Vector2 topTextFinalPos = new Vector2(0, 50);

    [SerializeField] private Vector2 flashInitSize = new Vector2(850, 250);
    [SerializeField] private Vector2 flashFinalSize = new Vector2(850, 50);

    [SerializeField] private Vector2 backgroundInitSize = new Vector2(800, 0);
    [SerializeField] private Vector2 backgroundFinalSize = new Vector2(800, 350);


    // [SerializeField] private Vector2 msgSize = new Vector2(400, 100);


    void Start()
    {
    //     // _material = VfxEffectController.GetMaterial<Image>(glow);

        backgroundRectTransform = background.GetComponent<RectTransform>();
        flashRectTransform = flash.GetComponent<RectTransform>();
        topMsgRectTransform = topMsg.GetComponent<RectTransform>();
        bottomMsgRectTransform = bottomMsg.GetComponent<RectTransform>();

    //     backgroundImg =  background.GetComponent<Image>();
        flashImg =  flash.GetComponent<Image>();
    //     // // glowImg =  glow.GetComponent<Image>();

        topMsgTmp =  topMsg.GetComponent<TextMeshProUGUI>();
        bottomMsgTmp = bottomMsg.GetComponent<TextMeshProUGUI>();

    } 

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AnimateIn();
        }        
    }

    void AnimateIn()
    {
        background.SetActive(true);
        flash.SetActive(true);
        topMsg.SetActive(true);
        bottomMsg.SetActive(true);

    //     backgroundRectTransform.DOAnchorPos(bottomTextInitPos, 0);
        backgroundRectTransform.sizeDelta = backgroundInitSize;

    //     flashRectTransform.DOAnchorPos(bottomTextInitPos, 0);
        flashRectTransform.sizeDelta = flashInitSize;

        topMsgRectTransform.DOAnchorPos(topTextIniPos, 0);
        // topMsgRectTransform.sizeDelta = msgSize;
        
        bottomMsgRectTransform.DOAnchorPos(bottomTextInitPos, 0);
    //     fadedMsgRectTransform.sizeDelta = msgSize;

    //     backgroundImg.DOFade(0, 0.001f);
        flashImg.DOFade(flashAplhaMin, 0);

        topMsgTmp.DOFade(0, 0);
        bottomMsgTmp.DOFade(0, 0);
    //     // glowImg.DOFade(0, 0.001f);

        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(backgroundRectTransform.DOSizeDelta(backgroundFinalSize, backgroundAnimDuraton));
        tweenSeq.Insert(backgroundAnimDuraton/2, topMsgTmp.DOFade(1, topMsgAlphaAnimDuration));
        tweenSeq.Insert(backgroundAnimDuraton/2,topMsgRectTransform.DOAnchorPos(topTextFinalPos, topMsgMoveAnimDuration));
        tweenSeq.Insert(backgroundAnimDuraton/2,bottomMsgTmp.DOFade(1, bottomMsgAlphaAnimDuration));
        tweenSeq.Insert(backgroundAnimDuraton/2,bottomMsgRectTransform.DOAnchorPos(bottomTextFinalPos, bottomMsgMoveAnimDuration));
        tweenSeq.Append(flashImg.DOFade(flashAplhaMax, flashAplhaAnimDuration));
        tweenSeq.Append(flashRectTransform.DOSizeDelta(flashFinalSize, flashDieAnimDuration));
        tweenSeq.Join(flashImg.DOFade(flashAplhaMin, flashAplhaAnimDuration));
        tweenSeq.Append(DOVirtual.DelayedCall(textDisplayDuration, () => AnimeOut()));

    }

    void AnimeOut()
    {
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(backgroundRectTransform.DOSizeDelta(backgroundInitSize, backgroundAnimDuraton));
        tweenSeq.Join(topMsgTmp.DOFade(0, topMsgAlphaAnimDuration/1.5f));
        tweenSeq.Join(bottomMsgTmp.DOFade(0, bottomMsgAlphaAnimDuration/1.5f));

        background.SetActive(true);
        flash.SetActive(true);
        topMsg.SetActive(true);
        bottomMsg.SetActive(true);

    }

}