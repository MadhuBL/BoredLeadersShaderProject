using UnityEngine; 

// By @Madhu
// This is the Controller part of the BattleBegin text animation, which is responsible for triggering the ainmation 
public class WordCollisionTextAnimationController : MonoBehaviour
{
    // This is the reference to scriptable object of the BattleBegin text animation
    [SerializeField] private WordCollisionTextAnimationDataSO wordCollisionData;

    void OnEnable()
    {
        TextEventManager.battleBeginsTextAnimEvent += Init;
    }

    void OnDisable()
    {
        TextEventManager.battleBeginsTextAnimEvent -= Init;
    }
    // This method calls the View part of the BattleBegin text animation
    void Init()
    {
        WordCollisionTextAnimationView battleBeginsView = GetComponent<WordCollisionTextAnimationView>();
        battleBeginsView.InitValueSetUp(wordCollisionData);
        battleBeginsView.AnimateIn();
    }

    

    
}

