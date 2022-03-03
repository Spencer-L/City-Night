using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightFlickerController : MonoBehaviour
{
    [SerializeField] private Material neonLight;
    private Color _neonColor;

    // flicker time rng
    [SerializeField] private float upperThreshold;
    [SerializeField] private float lowerThreshold;
    
    private float _timer = 0.0f;
    private float _flickerTime = 0.0f;
    private bool _flickerState;

    void Start()
    {
        _neonColor = neonLight.color;
    }

    void Update()
    {
        // generate random flicker time between 0.5-3 seconds
        if (_flickerTime == 0.0f)
        {
            _flickerTime = Random.Range(lowerThreshold, upperThreshold);
        }

        if (_timer >= _flickerTime)
        {
            _flickerTime = 0.0f;
            _timer = 0.0f;
            FlickerLight();
        }
        
        _timer += Time.deltaTime;
    }

    private void FlickerLight()
    {
        print("Flicker! " + _flickerState);
        _flickerState = !_flickerState;
        if (_flickerState)
        {
            neonLight.SetColor("_EmissiveColor", _neonColor * 1000f);
        }
        else
        {
            neonLight.SetColor("_EmissiveColor", _neonColor * 0);
        }
    }
}
