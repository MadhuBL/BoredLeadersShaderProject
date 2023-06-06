using UnityEngine;
using UnityEngine.UI;

public class CardFan2 : MonoBehaviour
{
    public float fanRadius = 100f;
    public float fanAngle = 90f;
    public float maxCardScale = 1.2f;
    public float cardSpacing = 10f;
    public Image[] imageComponents;

    private int cardCount;
    private float initialAngle;

    private void Start()
    {
        cardCount = imageComponents.Length;
        initialAngle = fanAngle / 2f;

        FanImages();
    }

    private void FanImages()
    {
        for (int i = 0; i < cardCount; i++)
        {   
            float angle = Mathf.Deg2Rad * (initialAngle - fanAngle * i / (cardCount - 1));

            float x = Mathf.Sin(angle) * -cardSpacing;

            float y = Mathf.Cos(angle) * fanRadius ;

            Vector3 position = new Vector3(x, y, 0f);
            Quaternion rotation = Quaternion.Euler(0f, 0f,  angle * Mathf.Rad2Deg);

            imageComponents[i].rectTransform.localPosition = position;
            imageComponents[i].rectTransform.localRotation = rotation;

            float scale = Mathf.Lerp(1f, maxCardScale, (float)i / (cardCount - 1));
            imageComponents[i].rectTransform.localScale = new Vector3(scale, scale, 1f);

            imageComponents[i].rectTransform.SetAsLastSibling();
        }
    }


}


