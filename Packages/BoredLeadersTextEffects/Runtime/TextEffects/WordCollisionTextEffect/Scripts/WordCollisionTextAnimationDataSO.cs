using TMPro;
using UnityEngine;
using UnityEngine.UI;

// By @Madhu
// This is the Model part of the BattleBegin text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/BattleBeginsData")]
public class WordCollisionTextAnimationDataSO : ScriptableObject
{

    public Sprite flashSprite;
    public Sprite backgroundSprite;
    public Sprite leftTextImgSprite;
    public Sprite rightTextImgSprite;

    public Color backgroundColor;
    public Color flashColor;
    public Color leftTextImgColor;
    public Color rightTextImgColor;

    public Material backgroundMaterial;
    public Material flashMaterial;
    public Material leftTextImgMaterial;
    public Material rightTextImgMaterial;

    public Vector2 rightTextSize;
    public Vector2 leftTextSize;
    public Vector2 rightTextInitPos;
    public Vector2 rightTextFinalPos;

    public Vector2 leftTextInitPos;
    public Vector2 leftTextFinalPos;

    public Vector2 flashInitSize;
    public Vector2 flashFinalSize;

    public Vector2 backgroundInitSize;
    public Vector2 backgroundFinalSize;

    public float backgroundAnimDuraton;
    public float msgAlphaAnimDuration;
    public float msgMoveAnimDuration;
    public float fadeMsgMoveDistance;
    public float fadeMsgMoveAnimDuration;
    public float fadeMsgAplhaMax;
    public float flashAplhaMin;
    public float flashAplhaMax;
    public float flashAplhaAnimDuration;
    public float flashDieAnimDuration;
    public float textDisplayDuration;
    public float ghostBoostMin;
    public float ghostBoostMax;
    public float ghostTransparencyMin;
    public float ghostTransparencyMax;
    public float ghostBlendMin;
    public float ghostBlendMax;
    public float ghostMatAnimDuraton;



}
