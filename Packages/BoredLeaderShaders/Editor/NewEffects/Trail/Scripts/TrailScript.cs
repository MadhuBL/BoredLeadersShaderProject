using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    public GameObject[] TrailPrefabs;
    void Start()
    {
        InvokeRepeating("CreateTrail", 2f, 2f );
    }

    void CreateTrail()
    {
        Vector3 pos = new Vector3(-2f, 4f, 8f);
        foreach(GameObject prefab in TrailPrefabs)
        {
            var go = Instantiate(prefab, pos, Quaternion.identity, transform );
            pos += new Vector3(.8f, 0f, 0f);
            Destroy(go, 4);
        }
        

        
    }
}
