using UnityEngine;
using UnityEngine.UI;

public class CardFan1 : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float fanAngle = 90f;
    public RectTransform[] cardRectTransforms;

    private float cardAngle;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        CalculateCardAngle();
    }

    private void Update()
    {
        RotateCards();
    }

    private void RotateCards()
    {
        for (int i = 0; i < cardRectTransforms.Length; i++)
        {
            float angle = cardAngle * i;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
            cardRectTransforms[i].rotation = Quaternion.RotateTowards(cardRectTransforms[i].rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void CalculateCardAngle()
    {
        if (cardRectTransforms.Length > 0)
        {
            cardAngle = fanAngle / (cardRectTransforms.Length - 1);
        }
    }









    





// To use this script:

// Create a new GameObject in your Unity scene or select an existing one to act as the parent object for the fan cards.
// Attach the FanCardScript component to the parent object.
// Assign the card objects' Transform components to the cardTransforms array in the FanCardScript component inspector.
// Adjust the rotationSpeed and fanAngle values as per your desired rotation speed and fan angle.
// Run the scene, and the cards should rotate in a fan shape around the parent object.
// Note: Make sure you have the necessary card objects with their respective Transform components assigned to the script. Adjust the script and UI elements according to your specific requirements.

    // public float rotationSpeed = 100f;
    // public float fanAngle = 90f;
    // public float fanDistance = 150f;
    // public Image[] imageComponents;

    // private float imageAngle;
    // private Vector3 initialPosition;

    // private void Start()
    // {
    //     initialPosition = transform.position;
    //     CalculateImageAngle();
    // }

    // private void Update()
    // {
    //     RotateImages();
    // }

    // private void RotateImages()
    // {
    //     for (int i = 0; i < imageComponents.Length; i++)
    //     {
    //         float angle = imageAngle * i;
    //         float x = Mathf.Cos(Mathf.Deg2Rad * angle) * fanDistance;
    //         float y = Mathf.Sin(Mathf.Deg2Rad * angle) * fanDistance;
    //         Vector3 targetPosition = initialPosition + new Vector3(x, y, 0f);
    //         Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
    //         imageComponents[i].rectTransform.position = Vector3.Lerp(imageComponents[i].rectTransform.position, targetPosition, rotationSpeed * Time.deltaTime);
    //         imageComponents[i].rectTransform.rotation = Quaternion.RotateTowards(imageComponents[i].rectTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    //     }
    // }

    // private void CalculateImageAngle()
    // {
    //     if (imageComponents.Length > 0)
    //     {
    //         imageAngle = fanAngle / (imageComponents.Length - 1);
    //     }
    // }









// To use this script:

// Create a new GameObject in your Unity scene or select an existing one to act as the parent object for the fan cards.
// Attach the FanCardScript component to the parent object.
// Assign the card objects' Transform components to the cardTransforms array in the FanCardScript component inspector.
// Adjust the rotationSpeed and fanAngle values as per your desired rotation speed and fan angle.
// Run the scene, and the cards should rotate in a fan shape around the parent object.
// Note: Make sure you have the necessary card objects with their respective Transform components assigned to the script. Adjust the script and UI elements according to your specific requirements.

    // public float rotationSpeed = 100f;
    // public float fanAngle = 90f;
    // public RectTransform[] cardRectTransforms;

    // private float cardAngle;
    // private Vector3 initialPosition;

    // private void Start()
    // {
    //     initialPosition = transform.position;
    //     CalculateCardAngle();
    // }

    // private void Update()
    // {
    //     RotateCards();
    // }

    // private void RotateCards()
    // {
    //     for (int i = 0; i < cardRectTransforms.Length; i++)
    //     {
    //         float angle = cardAngle * i;
    //         Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
    //         cardRectTransforms[i].rotation = Quaternion.RotateTowards(cardRectTransforms[i].rotation, targetRotation, rotationSpeed * Time.deltaTime);
    //     }
    // }

    // private void CalculateCardAngle()
    // {
    //     if (cardRectTransforms.Length > 0)
    //     {
    //         cardAngle = fanAngle / (cardRectTransforms.Length - 1);
    //     }
    // }







    // public float fanAngle = 90f;
    // public float fanRadius = 200f;
    // public float fanOffset = 20f;
    // public float maxScale = 1.2f;
    // public AnimationCurve scaleCurve;

    // private Image[] imageComponents;
    // private Vector3 initialPosition;

    // private void Start()
    // {
    //     imageComponents = GetComponentsInChildren<Image>();
    //     initialPosition = transform.position;

    //     FanCards();
    // }

    // private void FanCards()
    // {
    //     float cardAngle = fanAngle / (imageComponents.Length - 1);
    //     float currentAngle = -fanAngle * 0.5f;

    //     for (int i = 0; i < imageComponents.Length; i++)
    //     {
    //         float radian = currentAngle * Mathf.Deg2Rad;
    //         float x = Mathf.Sin(radian) * fanRadius;
    //         float y = -Mathf.Cos(radian) * fanRadius;

    //         Vector3 cardPosition = initialPosition + new Vector3(x, y, 0f);
    //         imageComponents[i].rectTransform.localPosition = cardPosition;

    //         float scale = scaleCurve.Evaluate(currentAngle / fanAngle);
    //         imageComponents[i].rectTransform.localScale = Vector3.one * scale * maxScale;

    //         currentAngle += cardAngle;
    //     }
    // }









// To use this script:

// Create a new GameObject in your Unity scene or select an existing one to act as the parent object for the fan cards.
// Attach the FanCardUIScript component to the parent object.
// Assign the card objects' RectTransform components to the cardRectTransforms array in the FanCardUIScript component inspector.
// Adjust the rotationSpeed and fanAngle values as per your desired rotation speed and fan angle.
// Run the scene, and the cards should rotate in a fan shape around the parent object.
// Note: Make sure you have the necessary card objects with their respective RectTransform components assigned to the script. Adjust the script and UI elements according to your specific requirements.

    // public float rotationSpeed = 100f;
    // public float fanAngle = 90f;
    // public RectTransform[] cardRectTransforms;

    // private float cardAngle;
    // private Vector3 initialPosition;

    // private void Start()
    // {
    //     initialPosition = transform.position;
    //     CalculateCardAngle();
    // }

    // private void Update()
    // {
    //     RotateCards();
    // }

    // private void RotateCards()
    // {
    //     for (int i = 0; i < cardRectTransforms.Length; i++)
    //     {
    //         float angle = cardAngle * i;
    //         Vector3 targetRotation = new Vector3(0f, 0f, angle);
    //         cardRectTransforms[i].localRotation = Quaternion.RotateTowards(cardRectTransforms[i].localRotation, Quaternion.Euler(targetRotation), rotationSpeed * Time.deltaTime);
    //     }
    // }

    // private void CalculateCardAngle()
    // {
    //     if (cardRectTransforms.Length > 0)
    //     {
    //         cardAngle = fanAngle / (cardRectTransforms.Length - 1);
    //     }
    // }









// To use this script:

// Create a new GameObject in your Unity scene or select an existing one to act as the parent object for the fan images.
// Attach the FanImageScript component to the parent object.
// Assign the image objects' Image components to the imageComponents array in the FanImageScript component inspector.
// Adjust the rotationSpeed, fanAngle, and fanDistance values as per your desired rotation speed, fan angle, and distance between the images.
// Run the scene, and the images should fan out around the parent object.
// Note: Make sure you have the necessary image objects with their respective Image components assigned to the script. Adjust the script and UI elements according to your specific requirements.

    // public float rotationSpeed = 100f;
    // public float fanAngle = 90f;
    // public float fanDistance = 100f;
    // public Image[] imageComponents;

    // private float imageAngle;
    // private Vector3 initialPosition;

    // private void Start()
    // {
    //     initialPosition = transform.position;
    //     CalculateImageAngle();
    //     ArrangeImages();
    // }

    // private void Update()
    // {
    //     RotateImages();
    // }

    // private void RotateImages()
    // {
    //     for (int i = 0; i < imageComponents.Length; i++)
    //     {
    //         float angle = imageAngle * i;
    //         Vector3 targetPosition = Quaternion.Euler(0f, 0f, angle) * new Vector3(0f, fanDistance, 0f);
    //         imageComponents[i].rectTransform.localPosition = Vector3.MoveTowards(imageComponents[i].rectTransform.localPosition, targetPosition, rotationSpeed * Time.deltaTime);
    //     }
    // }

    // private void ArrangeImages()
    // {
    //     for (int i = 0; i < imageComponents.Length; i++)
    //     {
    //         float angle = imageAngle * i;
    //         Vector3 position = Quaternion.Euler(0f, 0f, angle) * new Vector3(0f, fanDistance, 0f);
    //         imageComponents[i].rectTransform.localPosition = position;
    //     }
    // }

    // private void CalculateImageAngle()
    // {
    //     if (imageComponents.Length > 0)
    //     {
    //         imageAngle = fanAngle / (imageComponents.Length - 1);
    //     }
    // }


}
