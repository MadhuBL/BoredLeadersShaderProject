using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By @Madhu
// This is the Controller part of the YourTurn text animation, which is responsible for triggering the ainmation 
public class YourTurnController : MonoBehaviour
{
    // This is the reference to scriptable object of the YourTurn text animation
    [SerializeField] private YourTurnTextAnimSO yourTurnTextData;

    void OnEnable()
    {
        EventManager.YourTurnTextAnimEvent += Init;
    }

    void OnDisable()
    {
        EventManager.YourTurnTextAnimEvent -= Init;
    }

    void Init()
    {
        YourTurnView yourTurnView = GetComponent<YourTurnView>();
        yourTurnView.InitValueSetUp(yourTurnTextData);
        yourTurnView.AnimateIn();
    }
}
