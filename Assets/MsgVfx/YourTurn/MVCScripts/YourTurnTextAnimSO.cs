using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// By @Madhu
// This is the Model part of the YourTurn text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/YourTurnData")]
public class YourTurnTextAnimSO : ScriptableObject
{

    public Sprite flashSprite;
    public Sprite backgroundSprite;
    public Color backgroundColor;
    public Color flashColor;
    public Material backgroundMaterial;
    public Material flashMaterial;
    public string mainTextContent;
    public string fadeTextContent;
    public TMP_FontAsset fadeTextFont;
    public TMP_FontAsset mainTextFont;
    public VertexGradient mainTextColor;
    public VertexGradient fadeTextColor;
    public float mainTextOutlineWidth;
    public float fadeTextOutlineWidth;
    public Color mainTextOutlineColor;
    public Color fadeTextOutlineColor;
    public float flashAplhaMin;
    public float flashAplhaMax;
    public float fadeTextAplhaMax;
    public float animateInDuration;
    public float animateOutDuration;
    public float displayTextDuration;
    public float textFadeOutDuration;
    public Vector2 rightPos;
    public Vector2 leftPos;
    public Vector2 flashSize;
    public Vector2 backgroundSize;
    public Vector2 initMsgSize;
    public Vector2 finalMsgSize;


}
