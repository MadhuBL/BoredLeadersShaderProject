using System;

using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action battleBeginsTextAnimEvent;
    public static event Action YourTurnTextAnimEvent;
    public static event Action CastleRaidedTextAnimEvent;

    

    public static void battleBeginsTextAnimEventCaller()
    {
        battleBeginsTextAnimEvent?.Invoke();
    }

    public static void YourTurnTextAnimEventCaller()
    {
        YourTurnTextAnimEvent?.Invoke();
    }

    public static void CastleRaidedTextAnimEventCaller()
    {
        CastleRaidedTextAnimEvent?.Invoke();
    }
}
