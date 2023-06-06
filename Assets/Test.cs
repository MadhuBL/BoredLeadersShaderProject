using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans.DORotate(new Vector3(45,0,0), 0.1f);
        transform.DORotate(new Vector3(0,360,0), 0.2f, RotateMode.FastBeyond360).SetLoops(12,LoopType.Incremental ).SetEase(Ease.Linear);

    }


}
