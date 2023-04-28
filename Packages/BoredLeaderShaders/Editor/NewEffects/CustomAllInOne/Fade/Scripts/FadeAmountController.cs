using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// using DG.Tweening;

public class FadeAmountController : MonoBehaviour
{
    private Material _material;
    private Button _btn;
    private float _fadeAmount;
    private bool _isCardActivated;


    void Start()
    {
        _fadeAmount = -0.1f;
        _isCardActivated = false;
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => CardActivated());

        _material = GetComponent<Image>().material;
        _material.SetFloat("_FadeAmount", _fadeAmount);
        
    }

    void Update()
    {
        if(_isCardActivated)
        {
            FadeOut();
        }
    }

    void FadeOut()
    {
        _fadeAmount += Time.deltaTime;

		if (_fadeAmount >= 1f)
		{
			_fadeAmount = 1f;
            _isCardActivated = false;

		}

		_material.SetFloat("_FadeAmount", _fadeAmount);

    }

    void CardActivated()
	{
		_isCardActivated = true;
	}


    void OnDisable()
    {
        _btn.onClick.RemoveAllListeners();
    }
}
