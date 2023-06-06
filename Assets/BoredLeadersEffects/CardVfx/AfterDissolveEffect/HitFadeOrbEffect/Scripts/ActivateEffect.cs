using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShaderEffects;


public class ActivateEffect : MonoBehaviour
{
    // private ParticleSystem _particleSystem;
    // ParticleSystemRenderer _particleSystemRenderer;
    // private Material _mat;
    // private float _alphaValue = 0f;
    // private float _pinchAmount = 0.5f;
    // private bool _activateEffect = false;
    // private bool _deactivateEffect = false;
    // private bool _endEffect = false;
    public Material mat;
    
    

    void Start()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)particleSystem.GetComponent<Renderer>();
        particleSystemRenderer.material = mat;
        

        // _mat = VfxEffectController.GetMaterial<ParticleSystem>(gameObject);
        // VfxEffectController.SetCustomMatPara(_mat, "_Alpha", _alphaValue);
        // VfxEffectController.SetCustomMatPara(_mat, "_PinchUvAmount", _pinchAmount);

        // Debug.Log("HI");
        // _particleSystem = GetComponent<ParticleSystem>();
        // _particleSystemRenderer = (ParticleSystemRenderer)GetComponent<ParticleSystem>().GetComponent<Renderer>();
        // _mat = _particleSystemRenderer.material;
        // Debug.Log(_mat.name);

    //     // _mat.SetFloat("_Alpha", _alphaValue);
    //     // _mat.SetFloat("_PinchUvAmount", _pinchAmount);
    }

    // void OnEnable()
    // {
    //     HitFadeEffect.ActivateEffect += ActivateThisEffect; 
    // }

    // // void Update()
    // // {
    // //     if(_activateEffect)
    // //     {
    // //         DisplayEffect();
    // //     }
    // //     if(_deactivateEffect)
    // //     {
    // //         HideEffect();
    // //     }
    // //     if(_endEffect)
    // //     {
    // //         EndEffect();
    // //     }
    // // }

    // void ActivateThisEffect()
    // {
    //     DisplayEffect();
    //     // _activateEffect = true;
    //     _particleSystem.Play();
        
    // }

    // void DisplayEffect()
    // {
    //     VfxEffectController.LerpCustomMatPara(_mat, "_Alpha", 0f, 1f, 1f);
    //     VfxEffectController.LerpCustomMatPara(_mat, "_PinchUvAmount", _pinchAmount, 0f, 1);
    //     HideEffect();

	// 	// _alphaValue = 1f;
    //     // _mat.SetFloat("_Alpha", _alphaValue);

    //     // _pinchAmount -= Time.deltaTime;
        

	// 	// if (_pinchAmount <= 0f)
	// 	// {
	// 	// 	_pinchAmount = 0f;
	// 	// 	_activateEffect = false;
    //     //     _deactivateEffect = true;
	// 	// }

    //     // _mat.SetFloat("_PinchUvAmount", _pinchAmount);

    // }

    // void HideEffect()
    // {
    //     VfxEffectController.LerpCustomMatPara(_mat, "_PinchUvAmount", 0f, _pinchAmount, 1);
    //     EndEffect();

    //     // _pinchAmount += Time.deltaTime;
        
	// 	// if (_pinchAmount >= 0.5f)
	// 	// {
	// 	// 	_pinchAmount = 0.5f;
	// 	// 	_deactivateEffect = false;
    //     //     _endEffect = true;

	// 	// }

    //     // _mat.SetFloat("_PinchUvAmount", _pinchAmount);


    // }

    // void EndEffect()
    // {

    //     VfxEffectController.LerpCustomMatPara(_mat, "_Alpha", 1f, 0f, 1f);

    //     // _alphaValue = 0f;
    //     // _mat.SetFloat("_Alpha", _alphaValue);
    //     _particleSystem.Stop();
    // }

    //     void OnDisable()
    // {
    //     HitFadeEffect.ActivateEffect -= ActivateThisEffect; 
    // }


}
