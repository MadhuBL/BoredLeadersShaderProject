using System;
using DG.Tweening;
using ShaderEffects;
using UnityEngine;
using UnityEngine.UI;   

// By @Madhu
// This is the Controller part of the BattleBegin text animation, which is responsible for triggering the ainmation 
public class BattleBeginsController : MonoBehaviour
{
    // This is the reference to scriptable object of the BattleBegin text animation
    [SerializeField] private BattleBeginsTextAnimDataSO battleBeginsData;

    void OnEnable()
    {
        EventManager.battleBeginsTextAnimEvent += Init;
    }

    void OnDisable()
    {
        EventManager.battleBeginsTextAnimEvent -= Init;
    }
    // This method calls the View part of the BattleBegin text animation
    void Init()
    {
        BattleBeginsView battleBeginsView = GetComponent<BattleBeginsView>();
        battleBeginsView.InitValueSetUp(battleBeginsData);
        battleBeginsView.AnimateIn();
    }

    

    
}