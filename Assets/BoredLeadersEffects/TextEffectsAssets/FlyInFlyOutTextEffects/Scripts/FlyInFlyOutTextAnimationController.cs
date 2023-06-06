using UnityEngine;

// By @Madhu
// This is the Controller part of the YourTurn text animation, which is responsible for triggering the ainmation 
public class FlyInFlyOutTextAnimationController : MonoBehaviour
{
    // This is the reference to scriptable object of the YourTurn text animation
    [SerializeField] private FlyInFlyOutTextAnimationDataSO flyInFlyOutData;

    void OnEnable()
    {
        TextEventManager.YourTurnTextAnimEvent += Init;
    }

    void OnDisable()
    {
        TextEventManager.YourTurnTextAnimEvent -= Init;
    }

    void Init()
    {
        FlyInFlyOutTextAnimationView yourTurnView = GetComponent<FlyInFlyOutTextAnimationView>();
        yourTurnView.InitValueSetUp(flyInFlyOutData);
        yourTurnView.AnimateIn();
    }
}

