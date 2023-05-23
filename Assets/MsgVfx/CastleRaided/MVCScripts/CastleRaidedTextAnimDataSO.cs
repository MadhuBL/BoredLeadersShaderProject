using TMPro;
using UnityEngine;


// By @Madhu
// This is the Model part of the CastleRaided text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/CastleRaidedData")]
public class CastleRaidedTextAnimDataSO : ScriptableObject
{
    public Sprite backgroundSprite;
    public Color backgroundColor;
    public Material backgroundMaterial;
    public Sprite flashSprite;
    public Color flashColor;
    public Material flashMaterial;

    public string textContent;
    public TMP_FontAsset textFont;
    public VertexGradient textColor;
    public float textOutlineWidth;
    public Color textOutlineColor;

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