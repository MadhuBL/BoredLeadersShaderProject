using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TestMsgVfx : MonoBehaviour
{
    public TextMeshProUGUI msg;
    public RectTransform imgRectTransform;
    public RectTransform textRectTransform;

    [SerializeField] Vector2 initBackgroundSize;
    [SerializeField] Vector2 finalBackgroundSize;
    [SerializeField] Vector2 initMsgSize;
    [SerializeField] Vector2 finalMsgSize;



    void Update()
    {   
        if(Input.GetMouseButtonDown(0))
        {
            AnimExpandCompress();
        }
    }

    void AnimExpandCompress()
    {
        AnimExpand();
        DOVirtual.DelayedCall(1, () => AnimCompress());
    }

    void AnimExpand()
    {

        // imgRectTransform.gameObject.SetActive(true);
        imgRectTransform.DOAnchorPos(Vector2.zero, 0f) ;
        imgRectTransform.sizeDelta = initBackgroundSize;
        textRectTransform.sizeDelta = initMsgSize;

        // Animation
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Append(DOVirtual.DelayedCall(.5f, null));
        tweenSeq.Append(imgRectTransform.DOAnchorPos(Vector2.zero, 0f));
        tweenSeq.Append(imgRectTransform.DOSizeDelta(finalBackgroundSize, 1f)).SetEase(Ease.OutBounce);     
        tweenSeq.Join(textRectTransform.DOSizeDelta(finalMsgSize, 1f));
    }

    void AnimCompress()
    {

        // Animation
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Append(DOVirtual.DelayedCall(.5f, null));

        tweenSeq.Join(textRectTransform.DOSizeDelta(initMsgSize, .8f));
        tweenSeq.Join(imgRectTransform.DOSizeDelta(initBackgroundSize, 1f));

        // imgRectTransform.gameObject.SetActive(false);

    }

}
