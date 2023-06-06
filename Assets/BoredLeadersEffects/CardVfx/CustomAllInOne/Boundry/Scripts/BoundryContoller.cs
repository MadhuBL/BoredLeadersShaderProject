using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShaderEffects;


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

        _material = CommonVfxEffect.GetMaterial<Image>(gameObject);
        CommonVfxEffect.SetCustomMatPara(_material, "_OutlineAlpha", 0f);

        
    }

    void Update()
    {
        if(_isCardActivated)
        {
            CommonVfxEffect.SetCustomMatPara(_material, "_OutlineAlpha", 1f);
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