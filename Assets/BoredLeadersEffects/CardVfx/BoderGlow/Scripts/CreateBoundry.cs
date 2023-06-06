using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateBoundry : MonoBehaviour
{
	private Button _btn;
    private RectTransform _rt;
    private bool _isClickable = true;


    void Start()
    {
        _rt = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        ButtonClick.CardClickAction += CardActivated;
    }


    void CardActivated()
    {
        if(!_isClickable)
        {
            return;
        }

        _rt.sizeDelta  += new Vector2(2f,3f);
        _isClickable = false;
        
    }


    
	void OnDisable()
	{
        ButtonClick.CardClickAction -= CardActivated;
	}
}
