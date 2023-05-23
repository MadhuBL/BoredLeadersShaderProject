using TMPro;
using UnityEngine;
using UnityEngine.UI;

// By @Madhu
// This is the Model part of the BattleBegin text animation, which has all the data
[CreateAssetMenu (fileName = "TextAnimationData", menuName = "TextAnimationData/BattleBeginsData")]
public class BattleBeginsTextAnimDataSO : ScriptableObject
{

    public Sprite flashSprite;
    public Sprite backgroundSprite;
    public Color backgroundColor;
    public Color flashColor;
    public Material backgroundMaterial;
    public Material flashMaterial;

    public string leftTextContent;
    public string rightTextContent;
    public TMP_FontAsset rightTextFont;
    public TMP_FontAsset leftTextFont;
    public VertexGradient leftTextColor;
    public VertexGradient rightTextColor;
    public float leftTextOutlineWidth;
    public float rightTextOutlineWidth;
    public Color leftTextOutlineColor;
    public Color rightTextOutlineColor;


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



}
