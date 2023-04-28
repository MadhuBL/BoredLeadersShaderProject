using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFadeEffect : MonoBehaviour
{
	public static event Action ActivateEffect;

    private Material _material;
    private Button _btn;
    private float _fadeAmount;
    private float _hitEffectBlend;
    private bool _isHitEffectIn;
    private bool _isCardActivated;


    void Start()
    {
        _fadeAmount = -0.1f;
        _hitEffectBlend = 0f;
        _isCardActivated = false;
        _isHitEffectIn = false;

        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(CardActivated);

        _material = GetComponent<Image>().material;
        _material.SetFloat("_FadeAmount", _fadeAmount);
		_material.SetFloat("_HitEffectBlend", _hitEffectBlend);
    }

    void Update()
    {

        if(_isCardActivated)
        {
            HitEffectIn();
        }

        if(_isHitEffectIn)
        {
            ActivateEffect.Invoke();
            HitEffectOut();

        }
    }

    void HitEffectIn()
    {
        _hitEffectBlend += Time.deltaTime *10f;

		if (_hitEffectBlend >= 1f)
		{
            _isHitEffectIn = true;
            _isCardActivated = false;
		}

		_material.SetFloat("_HitEffectBlend", _hitEffectBlend);

    }

    void HitEffectOut()
    {
        _hitEffectBlend -= Time.deltaTime *10f;
        if (_hitEffectBlend <= 0f)
        {
            _hitEffectBlend = 0f;
        }
		_material.SetFloat("_HitEffectBlend", _hitEffectBlend);

        StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(.2f);
        _fadeAmount += Time.deltaTime * 2f;

		if (_fadeAmount >= 1f)
		{
			_fadeAmount = 1f;
            _isHitEffectIn = false;

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
