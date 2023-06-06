using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using ShaderEffects;

public class TestMsgVfx1 : MonoBehaviour
{
    public ParticleSystem particleSys;
    public Image img;
    public TextMeshProUGUI msg;
    public RectTransform imgRectTransform;
    public RectTransform textRectTransform;
    public float imgWidth = 350;
    public float imgHeight = 100;
    public float initialMsgWidth = 250;
    public float finallMsgWidth = 250 - 100;
    public float msgHeight = 50;
    public float aplhaMax = 0;
    public float aplhaMin = 1;




    private Material _material;

    void Update()
    {   
        if(Input.GetKey(KeyCode.Space))
        {
            AnimFadeInOut();
        }
    }

    void AnimFadeInOut()
    {
        AnimFadeIn();
        DOVirtual.DelayedCall(.5f, () => AnimFadeOut());
        // AnimFadeOut();
    }

    void AnimFadeIn()
    {
        // Image img;
        // TextMeshProUGUI msg;
        // RectTransform imgRectTransform = imgRt;
        // RectTransform textRectTransform = textRt;
        // imgRectTransform.gameObject.SetActive(true);
        // Initial Setup
        _material = CommonVfxEffect.GetMaterial<Image>(imgRectTransform.gameObject);
        imgRectTransform.DOAnchorPos(Vector2.zero, 0f);
        // imgRectTransform.sizeDelta = new Vector2(350, 100);
        textRectTransform.sizeDelta = new Vector2(250, 50);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostColorBoost",0);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostBlend",0);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostTransparency",0);
        Color tmpColor = msg.color;     tmpColor.a = 0;     msg.color = tmpColor;
        Color imgColor = img.color;     imgColor.a = 0;     img.color = imgColor;

        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Append(DOVirtual.DelayedCall(.5f, null));
        // fade in image
        tweenSeq.Join(DOVirtual.Float(0, 1, .5f, v => {imgColor.a = v;  img.color = imgColor; } )).SetEase(Ease.Linear).SetDelay(.2f);
        // fade in text
        tweenSeq.Join(DOVirtual.Float(0, 1, .5f, v => {tmpColor.a = v;  msg.color = tmpColor; } )).SetEase(Ease.Linear);
        // Scale text to smaller font size
        tweenSeq.Join(textRectTransform.DOSizeDelta(new Vector2(150,50), .5f));
        particleSys.Play();

    }

        void AnimFadeOut()
    {
        // Image img;
        // TextMeshProUGUI msg;
        // RectTransform imgRectTransform;
        // RectTransform textRectTransform;
        // Initial Setup
        Color tmpColor = msg.color;
        Color imgColor = img.color;
        
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Append(DOVirtual.DelayedCall(.5f, null));
        tweenSeq.Join(DOVirtual.Float(0, 5, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(0, .95f, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(0, 1, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(0, 0.1f, 1f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_PinchUvAmount",v); } )).SetEase(Ease.Linear);
        tweenSeq.Append(DOVirtual.Float(1, 0, .5f, v => {imgColor.a = v;  img.color = imgColor; } )).SetEase(Ease.Linear);
        tweenSeq.Append(DOVirtual.Float(1, 0, .5f, v => {tmpColor.a = v;  msg.color = tmpColor; } )).SetEase(Ease.Linear);

        // tweenSeq.Append(DOVirtual.DelayedCall(.5f, null));
        // tweenSeq.Join(DOVirtual.Float(5, 0, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        // tweenSeq.Join(DOVirtual.Float(0, .95f, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        // tweenSeq.Join(DOVirtual.Float(0, 1, .5f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        // // tweenSeq.Join(DOVirtual.Float(0, 0.1f, 1f, v => {CommonVfxEffect.SetCustomMatPara(_material,"_PinchUvAmount",v); } )).SetEase(Ease.Linear);
        // tweenSeq.Append(DOVirtual.Float(1, 0, .5f, v => {imgColor.a = v;  img.color = imgColor; } )).SetEase(Ease.Linear);
        // tweenSeq.Append(DOVirtual.Float(1, 0, .5f, v => {tmpColor.a = v;  msg.color = tmpColor; } )).SetEase(Ease.Linear);
        // // imgRectTransform.gameObject.SetActive(false);

        
    }
}
