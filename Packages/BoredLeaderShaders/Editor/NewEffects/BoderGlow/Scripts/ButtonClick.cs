using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Events;
using System;

public class ButtonClick : MonoBehaviour
{
    public static event Action CardClickAction;
    private Button _btn;
    
    // Subscribe OnCardClicked to button click event
    void Start()
    {   
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => OnCardClicked());
    }

    // This Method Raises an event when card is clicked
    public void OnCardClicked()
    {   
        CardClickAction?.Invoke();
        // gameObject.SetActive(false);
    }

    // Removing all subscriptions form button click event
    void OnDisabl()
    {
        _btn.onClick.RemoveAllListeners();
    }

}
