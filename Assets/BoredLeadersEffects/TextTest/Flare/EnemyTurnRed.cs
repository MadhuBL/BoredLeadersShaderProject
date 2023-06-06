using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using ShaderEffects;

public class EnemyTurnRed : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _textMsg;
    [SerializeField] private RectTransform _backgroundRectTransform;
    [SerializeField] private RectTransform _flasRectTransform;
    [SerializeField] private RectTransform _textRectTransform;
    [SerializeField] private Image _flashImg;
    [SerializeField] private TextMeshProUGUI _textTmp;
    [SerializeField] private ParticleSystem _particleSys;



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


    private Material _material;



    void Start()
    {
        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flasRectTransform = _flash.GetComponent<RectTransform>();
        _textRectTransform = _textMsg.GetComponent<RectTransform>();

        _flashImg = _flash.GetComponent<Image>();
        _textTmp = _textMsg.GetComponent<TextMeshProUGUI>();

        _material = CommonVfxEffect.GetMaterial<Image>(_flasRectTransform.gameObject);

    }

    void Update()
    {   
        if(Input.GetMouseButtonDown(0))
        {
            AnimFadeInOut();
        }
    }

    void AnimFadeInOut()
    {
        AnimFadeIn();
        DOVirtual.DelayedCall(.5f, () => AnimFadeOut());
    }

    void AnimFadeIn()
    {
        _flash.SetActive(true);
        _textMsg.SetActive(true);

        _backgroundRectTransform.DOAnchorPos(Vector2.zero, 0f);
        _flasRectTransform.DOAnchorPos(Vector2.zero, 0f);

        _flasRectTransform.sizeDelta = _flashSize;
        _backgroundRectTransform.sizeDelta = _backgroundInitSize;
        
        _flashImg.DOFade(0, 0);
        _textRectTransform.sizeDelta = _initMsgSize;
        _textTmp.DOFade(0, 0);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostColorBoost", _ghostBoostMax);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostBlend", _ghostBlendMin);
        CommonVfxEffect.SetCustomMatPara(_material,"_GhostTransparency", _ghostTransparencyMin);


        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundFinalSize, _backgroundAnimDuraton));
        tweenSeq.Join(_flashImg.DOFade(1, _flashFadeInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textTmp.DOFade(1, _textFadeInDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textRectTransform.DOSizeDelta(_finalMsgSize, _textMoveAnimDuration));
        _particleSys.Play();

    }

        void AnimFadeOut()
    {

        
        Sequence tweenSeq = DOTween.Sequence();
        tweenSeq.Join(DOVirtual.Float(_ghostBoostMax, _ghostBoostMin, _ghostMatAnimDuraton, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostColorBoost",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostBlendMin, _ghostBlendMax, _ghostMatAnimDuraton, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostBlend",v); } )).SetEase(Ease.Linear);
        tweenSeq.Join(DOVirtual.Float(_ghostTransparencyMin, _ghostTransparencyMax, _ghostMatAnimDuraton, v => {CommonVfxEffect.SetCustomMatPara(_material,"_GhostTransparency",v); } )).SetEase(Ease.Linear);
        tweenSeq.Append(_flashImg.DOFade(0, _flashFadeOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_textTmp.DOFade(0, _textFadeOutDuration)).SetEase(Ease.Linear);
        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundInitSize, _backgroundAnimDuraton));


        // _background.SetActive(false);
        // _flash.SetActive(false);
        // _textMsg.SetActive(false);


        
    }
}
