using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleRaidedController : MonoBehaviour
{
    // This is the reference to scriptable object of the YourTurn text animation
    [SerializeField] private CastleRaidedTextAnimDataSO castleRaidedTextData;

    void OnEnable()
    {
        EventManager.CastleRaidedTextAnimEvent += Init;
    }

    void OnDisable()
    {
        EventManager.CastleRaidedTextAnimEvent -= Init;
    }

    void Init()
    {
        CastleRaidedView castleRaidedView = GetComponent<CastleRaidedView>();
        castleRaidedView.InitValueSetUp(castleRaidedTextData);
        castleRaidedView.AnimateIn();
    }
}
