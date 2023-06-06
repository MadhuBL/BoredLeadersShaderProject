using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShaderEffects;


public class Dissolve : MonoBehaviour
{
	public static event Action ActivateEffect1;
	private Material _material;
    private Button _btn;
	private bool _isDissolving = false;
	private float _fade = 1f;

	void Start()
	{
		// Get a reference to the material
		// _material = GetComponent<Image>().material;
		// _material.SetFloat("_Fade", _fade);
		_btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => DissolveCard());

		_material = CommonVfxEffect.GetMaterial<Image>(gameObject);
        CommonVfxEffect.SetCustomMatPara(_material, "_Fade", _fade);
	}

	// void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
	// 	{
	// 		_isDissolving = true;
	// 		ActivateEffect1.Invoke();
	// 	}

	// 	if (_isDissolving)
	// 	{
	// 		DissolveCard();
	// 	}
    // }

	void DissolveCard()
	{
        CommonVfxEffect.LerpCustomMatPara(_material, "_Fade", _fade, 0f, 1);

		// _fade -= Time.deltaTime *2f;
		

		// if (_fade <= 0f)
		// {
		// 	_fade = 0f;
		// 	_isDissolving = false;
			
		// }

		// // Set the property
		// _material.SetFloat("_Fade", _fade);
		

	}
}
