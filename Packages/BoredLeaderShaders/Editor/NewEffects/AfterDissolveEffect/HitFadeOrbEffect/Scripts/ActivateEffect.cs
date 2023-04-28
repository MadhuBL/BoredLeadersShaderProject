using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    ParticleSystemRenderer _particleSystemRenderer;
    private Material _mat;
    private float _alphaValue = 0f;
    private float _pinchAmount = 0.5f;
    private bool _activateEffect = false;
    private bool _deactivateEffect = false;
    private bool _endEffect = false;

    
    

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystemRenderer = (ParticleSystemRenderer)GetComponent<ParticleSystem>().GetComponent<Renderer>();
        _mat = _particleSystemRenderer.material;
        _mat.SetFloat("_Alpha", _alphaValue);
        _mat.SetFloat("_PinchUvAmount", _pinchAmount);
    }

    void OnEnable()
    {
        HitFadeEffect.ActivateEffect += ActivateThisEffect; 
    }

    void Update()
    {
        if(_activateEffect)
        {
            DisplayEffect();
        }
        if(_deactivateEffect)
        {
            HideEffect();
        }
        if(_endEffect)
        {
            EndEffect();
        }
    }

    void ActivateThisEffect()
    {
        _activateEffect = true;
        _particleSystem.Play();
        
    }

    void DisplayEffect()
    {
		_alphaValue = 1f;
        _mat.SetFloat("_Alpha", _alphaValue);

        _pinchAmount -= Time.deltaTime;
        

		if (_pinchAmount <= 0f)
		{
			_pinchAmount = 0f;
			_activateEffect = false;
            _deactivateEffect = true;
		}

        _mat.SetFloat("_PinchUvAmount", _pinchAmount);

    }

    void HideEffect()
    {
        _pinchAmount += Time.deltaTime;
        
		if (_pinchAmount >= 0.5f)
		{
			_pinchAmount = 0.5f;
			_deactivateEffect = false;
            _endEffect = true;

		}

        _mat.SetFloat("_PinchUvAmount", _pinchAmount);

    }

    void EndEffect()
    {
        _alphaValue = 0f;
        _mat.SetFloat("_Alpha", _alphaValue);
        _particleSystem.Pause();
    }

        void OnDisable()
    {
        HitFadeEffect.ActivateEffect -= ActivateThisEffect; 
    }


}
