

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundryContoller : MonoBehaviour
{
    private Material _material;
    private Button _btn;
    private bool _isCardActivated;


    void Start()
    {
        _isCardActivated = false;
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => CardActivated());

        _material = GetComponent<Image>().material;
        _material.SetFloat("_OutlineAlpha", 0f);
        
    }

    void Update()
    {
        if(_isCardActivated)
        {
		    _material.SetFloat("_OutlineAlpha", 1f);
            _isCardActivated = false;
        }
    }

    public void CardActivated()
	{
		_isCardActivated = true;
	}

    void OnDisable()
    {
        _btn.onClick.RemoveAllListeners();
    }
}