using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// By @Madhu
// This is the Model part of the YourTurn text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/YourTurnData")]
public class FlyInFlyOutTextAnimationDataSO : ScriptableObject
{

    public Sprite flashSprite;
    public Sprite backgroundSprite;
    public Sprite textImageSprite;
    public Color backgroundColor;
    public Color flashColor;
    public Material backgroundMaterial;
    public Material flashMaterial;
    public Material textImageMaterial;
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
