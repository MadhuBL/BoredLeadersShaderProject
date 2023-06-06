using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFps : MonoBehaviour
{
    public TextMeshProUGUI FpsText;
    private float _pollingTime = 1f;
    private float _time;
    private int _frameCount;


    void Update()
    {
        _time += Time.deltaTime;
        _frameCount++;

        if(_time >= _pollingTime)
        {
            int frameRate = Mathf.RoundToInt(_frameCount/_time);
            FpsText.text = frameRate.ToString() + " FPS";

            _time -= _pollingTime;
            _frameCount = 0;
        }
    }
}
