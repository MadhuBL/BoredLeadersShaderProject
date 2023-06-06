using UnityEngine;

public class StompEffectTextAnimationController : MonoBehaviour
{
    // This is the reference to scriptable object of the YourTurn text animation
    [SerializeField] private StompEffectTextAnimationDataSO stompEffectData;

    void OnEnable()
    {
        TextEventManager.CastleRaidedTextAnimEvent += Init;
    }

    void OnDisable()
    {
        TextEventManager.CastleRaidedTextAnimEvent -= Init;
    }

    void Init()
    {
        StompEffectTextAnimationView castleRaidedView = GetComponent<StompEffectTextAnimationView>();
        castleRaidedView.InitValueSetUp(stompEffectData);
        castleRaidedView.AnimateIn();
    }
}


