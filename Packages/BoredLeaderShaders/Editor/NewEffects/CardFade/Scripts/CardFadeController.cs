using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFadeController : MonoBehaviour
{
	private Button _btn;
    private Image _image;
	private Color _color;
	private bool _isCardActivated;
	private bool _isCardShowing;
	private bool _disableCard;
	private float _alphaValue;
	
	void Start()
	{
		_isCardActivated = false;
		_isCardShowing = false;
		_disableCard = false;
		_alphaValue = 0f;

		_btn = GetComponent<Button>();
		_btn.onClick.AddListener(() => CardActivated());

		_image = GetComponent<Image>();
		_color = _image.color;
		_color.a = _alphaValue;
		_image.color =_color;

	}
	void Update()
    {
		if (_isCardActivated)
		{
			FadeCardIn();
		}

		if (_isCardShowing)
		{
			FadeCardOut();
		}

		if(_disableCard)
		{
			gameObject.SetActive(false);
		}

    }

	void CardActivated()
	{
		// Debug.Log("working!!!");
		_isCardActivated = true;
	}

	void FadeCardIn()
	{
		_alphaValue += Time.deltaTime;

		if (_alphaValue >= 1f)
		{
			_alphaValue = 1f;
			_isCardActivated = false;
			
		}

		_color.a = _alphaValue;
		_image.color =_color;

		StartCoroutine("IsCardShowing");

	}

	IEnumerator IsCardShowing()
	{
		yield return new WaitForSeconds(3);
		_isCardShowing = true;
	}
	void FadeCardOut()
	{
		_alphaValue -= Time.deltaTime;

		if (_alphaValue <= 0f)
		{
			_alphaValue = 0f;
			_isCardShowing = false;
			_disableCard = true;
		}

		_color.a = _alphaValue;
		_image.color =_color;
	}

	
	void OnDisable()
	{
		_btn.onClick.RemoveAllListeners();
	}

}
