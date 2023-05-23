using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCaller : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            EventManager.battleBeginsTextAnimEventCaller();
            EventManager.YourTurnTextAnimEventCaller();
            EventManager.CastleRaidedTextAnimEventCaller();
        }
    }
}
