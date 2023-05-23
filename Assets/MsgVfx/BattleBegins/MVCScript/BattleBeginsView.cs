using System;
using DG.Tweening;
using ShaderEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

// By @Madhu
// This calss is the View part of the BattleBegin text animation which is responsible of the animation of the text
public class BattleBeginsView : MonoBehaviour
{

    // GameObjects
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _flash;
    [SerializeField] private GameObject _leftMsg;
    [SerializeField] private GameObject _leftFadeMsg;
    [SerializeField] private GameObject _rightMsg;
    [SerializeField] private GameObject _rightFadetMsg;

    // GameObject Components
    private RectTransform _backgroundRectTransform;                         
    private RectTransform _flashRectTransform;                          
    private RectTransform _leftMsgRectTransform;                            
    private RectTransform _leftFadeMsgRectTransform;                            

    private RectTransform _rightMsgRectTransform;                           
    private RectTransform _rightFadeMsgRectTransform;                           

    private Image _backgroundImg;                           
    private Image _flashImg;                            

    private TextMeshProUGUI _leftMsgTmp;                         
    private TextMeshProUGUI _leftFadeMsgTmp;       
    private TextMeshProUGUI _rightMsgTmp;                                                   
    private TextMeshProUGUI _rightFadeMsgTmp;                           

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
    [SerializeField] private Vector2 _textSize;
    [SerializeField] private Vector2 _rightTextInitPos;
    [SerializeField] private Vector2 _rightTextFinalPos;
    [SerializeField] private Vector2 _leftTextInitPos;
    [SerializeField] private Vector2 _leftTextFinalPos;
    [SerializeField] private Vector2 _flashInitSize;
    [SerializeField] private Vector2 _flashFinalSize;
    [SerializeField] private Vector2 _backgroundInitSize;
    [SerializeField] private Vector2 _backgroundFinalSize;

    // This metods sets up the variables and values of the parameter from the model part of the MVC and is used for running the animation 
    public void InitValueSetUp(BattleBeginsTextAnimDataSO battleBeginsData)
    {   
        // Activate gameobjects
        _background.SetActive(true);
        _flash.SetActive(true);
        _leftMsg.SetActive(true);
        _rightMsg.SetActive(true);

        _backgroundRectTransform = _background.GetComponent<RectTransform>();
        _flashRectTransform = _flash.GetComponent<RectTransform>();
        _leftMsgRectTransform = _leftMsg.GetComponent<RectTransform>();
        _rightMsgRectTransform = _rightMsg.GetComponent<RectTransform>();
        _leftFadeMsgRectTransform = _leftFadeMsg.GetComponent<RectTransform>();
        _rightFadeMsgRectTransform = _rightFadetMsg.GetComponent<RectTransform>();

        _backgroundImg =  _background.GetComponent<Image>();
        _flashImg =  _flash.GetComponent<Image>();
        
        _leftMsgTmp =  _leftMsg.GetComponent<TextMeshProUGUI>();
        _rightMsgTmp = _rightMsg.GetComponent<TextMeshProUGUI>();
        _leftFadeMsgTmp = _leftFadeMsg.GetComponent<TextMeshProUGUI>();
        _rightFadeMsgTmp = _rightFadetMsg.GetComponent<TextMeshProUGUI>();

        // set up sprites, materials, text and other parameters values needed for animation
        _backgroundImg.sprite =  battleBeginsData.backgroundSprite;
        _backgroundImg.material = battleBeginsData.backgroundMaterial;

        _flashImg.sprite = battleBeginsData.flashSprite;
        _flashImg.material = battleBeginsData.flashMaterial;

        _leftMsgTmp.text = battleBeginsData.leftTextContent;
        _rightMsgTmp.text = battleBeginsData.rightTextContent;
        _leftFadeMsgTmp.text = battleBeginsData.leftTextContent;
        _rightFadeMsgTmp.text = battleBeginsData.rightTextContent;
        _leftMsgTmp.colorGradient = battleBeginsData.leftTextColor;
        _rightMsgTmp.colorGradient = battleBeginsData.rightTextColor;
        _leftFadeMsgTmp.colorGradient = battleBeginsData.leftTextColor;
        _rightFadeMsgTmp.colorGradient = battleBeginsData.rightTextColor;

        _leftMsgTmp.outlineWidth = battleBeginsData.leftTextOutlineWidth;
        _rightMsgTmp.outlineWidth = battleBeginsData.rightTextOutlineWidth;
        _leftFadeMsgTmp.outlineWidth = battleBeginsData.leftTextOutlineWidth;
        _rightFadeMsgTmp.outlineWidth = battleBeginsData.rightTextOutlineWidth;
        _leftMsgTmp.outlineColor = battleBeginsData.leftTextOutlineColor;
        _rightMsgTmp.outlineColor = battleBeginsData.rightTextOutlineColor;
        _leftFadeMsgTmp.outlineColor = battleBeginsData.leftTextOutlineColor;
        _rightFadeMsgTmp.outlineColor = battleBeginsData.rightTextOutlineColor;

        _leftMsgTmp.font = battleBeginsData.leftTextFont;
        _rightMsgTmp.font = battleBeginsData.rightTextFont;
        _leftFadeMsgTmp.font = battleBeginsData.leftTextFont;
        _rightFadeMsgTmp.font = battleBeginsData.rightTextFont;;

        _textSize = battleBeginsData.rightTextSize;
        _backgroundAnimDuraton  = battleBeginsData.backgroundAnimDuraton ;
        _msgAlphaAnimDuration = battleBeginsData.msgAlphaAnimDuration;
        _msgMoveAnimDuration = battleBeginsData.msgMoveAnimDuration;
        _fadeMsgMoveDistance = battleBeginsData.fadeMsgMoveDistance;
        _fadeMsgMoveAnimDuration = battleBeginsData.fadeMsgMoveAnimDuration;
        _fadeMsgAplhaMax = battleBeginsData.fadeMsgAplhaMax;
        _flashAplhaMin = battleBeginsData.flashAplhaMin;
        _flashAplhaMax = battleBeginsData.flashAplhaMax;
        _flashAplhaAnimDuration = battleBeginsData.flashAplhaAnimDuration;
        _flashDieAnimDuration = battleBeginsData.flashDieAnimDuration;
        _textDisplayDuration = battleBeginsData.textDisplayDuration;
        _rightTextInitPos = battleBeginsData.rightTextInitPos;
        _rightTextFinalPos = battleBeginsData.rightTextFinalPos;
        _leftTextInitPos = battleBeginsData.leftTextInitPos;
        _leftTextFinalPos = battleBeginsData.leftTextFinalPos;
        _flashInitSize = battleBeginsData.flashInitSize;
        _flashFinalSize = battleBeginsData.flashFinalSize;
        _backgroundInitSize = battleBeginsData.backgroundInitSize;
        _backgroundFinalSize = battleBeginsData.backgroundFinalSize;


        InitAnimeSetUp();

    }

    // This method sets up the initial position and vaules of the gameobjects
    void InitAnimeSetUp()
    {
        _backgroundRectTransform.sizeDelta = _backgroundInitSize;
        _flashRectTransform.sizeDelta = _flashInitSize;
        _leftMsgRectTransform.sizeDelta = _textSize;
        _rightMsgRectTransform.sizeDelta = _textSize;
        _leftFadeMsgRectTransform.sizeDelta = _textSize;
        _rightFadeMsgRectTransform.sizeDelta = _textSize;


        _leftMsgRectTransform.DOAnchorPos(_leftTextInitPos, 0);
        _rightMsgRectTransform.DOAnchorPos(_rightTextInitPos, 0);
        _leftFadeMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _rightFadeMsgRectTransform.DOAnchorPos(Vector2.zero, 0);
        _flashImg.DOFade(_flashAplhaMin, 0);
        _leftMsgTmp.DOFade(0, 0);
        _rightMsgTmp.DOFade(0, 0);
        _leftFadeMsgTmp.DOFade(_fadeMsgAplhaMax, 0);
        _rightFadeMsgTmp.DOFade(_fadeMsgAplhaMax, 0);
    }
    
    // This method animates the text entering the screen
    public void AnimateIn()
    {

        float actualTextDisplayDuration = _textDisplayDuration - _flashDieAnimDuration -_fadeMsgMoveAnimDuration - _backgroundAnimDuraton;
        Sequence tweenSeq = DOTween.Sequence();

        tweenSeq.Join(_backgroundRectTransform.DOSizeDelta(_backgroundFinalSize, _backgroundAnimDuraton));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftMsgTmp.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _leftMsgRectTransform.DOAnchorPos(_leftTextFinalPos, _msgMoveAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightMsgTmp.DOFade(1, _msgAlphaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton/2, _rightMsgRectTransform.DOAnchorPos(_rightTextFinalPos, _msgMoveAnimDuration));
        // tweenSeq.Append(_leftFadeMsgRectTransform.DOAnchorPos(Vector2.right * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration ));
        tweenSeq.Append(_leftFadeMsgRectTransform.DOAnchorPos(Vector2.left * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration ));
        tweenSeq.Join(_rightFadeMsgRectTransform.DOAnchorPos(Vector2.right * _fadeMsgMoveDistance, _fadeMsgMoveAnimDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMax, _flashAplhaAnimDuration));
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _leftFadeMsgTmp.DOFade(0, 0));
        tweenSeq.Insert(_backgroundAnimDuraton + _fadeMsgMoveAnimDuration, _rightFadeMsgTmp.DOFade(0, 0));
        tweenSeq.Append(_flashRectTransform.DOSizeDelta(_flashFinalSize, _flashDieAnimDuration));
        tweenSeq.Join(_flashImg.DOFade(_flashAplhaMin, _flashAplhaAnimDuration));
        tweenSeq.Append(DOVirtual.DelayedCall(actualTextDisplayDuration, () => AnimeOut()));

    }

    // This method animates the text exiting the screen
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