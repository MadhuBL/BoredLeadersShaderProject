using System;

using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action battleBeginsTextAnimEvent;
    public static event Action YourTurnTextAnimEvent;

    public static void battleBeginsTextAnimEventCaller()
    {
        battleBeginsTextAnimEvent?.Invoke();
    }

    public static void YourTurnTextAnimEventCaller()
    {
        YourTurnTextAnimEvent?.Invoke();
    }
}
