using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TrailController : MonoBehaviour
{
    // TrailRenderer tr;

    // void Start()
    // {
    //     tr = GetComponent<TrailRenderer>();
    //     // tr.startWidth = 10f;

        

    // }

    // void Update()
    // {
    //     if(Input.GetKey(KeyCode.Space))
    //     {
    //         tr.startWidth += 1f;
    //         // ChangeTrailWidth();
    //     }
    //         // DOVirtual.Float(1f, 10f, 2, v => {tr.startWidth = v; }).SetEase(Ease.Linear);
    //         // tr.startWidth += 1f;

    // }

    public void ChangeTrailWidth() // GameObject gameObj, float fromVal, float toVal, float speed)
    {
        if(TryGetComponent<TrailRenderer>(out TrailRenderer trailRenderer))
        {
           DOVirtual.Float(1, 10, .1f, v => {trailRenderer.startWidth = v; }).SetEase(Ease.Linear);
        }
    }
}
