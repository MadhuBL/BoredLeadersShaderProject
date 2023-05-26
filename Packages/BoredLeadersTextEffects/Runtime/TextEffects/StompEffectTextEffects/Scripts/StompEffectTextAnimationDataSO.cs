using TMPro;
using UnityEngine;


// By @Madhu
// This is the Model part of the CastleRaided text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/CastleRaidedData")]
public class StompEffectTextAnimationDataSO : ScriptableObject
{
    public Sprite backgroundSprite;
    public Sprite flashSprite;
    public Sprite textImgSprite;
    public Color backgroundColor;
    public Color flashColor;
    public Color textImgColor;
    public Material backgroundMaterial;
    public Material flashMaterial;
    public Material textImgMaterial;

    public Vector2 backgroundInitSize;
    public Vector2 backgroundFinalSize;
    public Vector2 flashSize;
    public Vector2 initMsgSize;
    public Vector2 finalMsgSize;

    public float ghostBoostMin;
    public float ghostBoostMax;
    public float ghostTransparencyMin;
    public float ghostTransparencyMax;
    public float ghostBlendMin;
    public float ghostBlendMax;
    public float ghostMatAnimDuraton;
    public float backgroundAnimDuraton;
    public float flashFadeOutDuration;
    public float flashFadeInDuration;
    public float textFadeInDuration;
    public float textFadeOutDuration;
    public float textMoveAnimDuration;

}