using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;
    [SerializeField] private AudioSource flashLightClick;
    private bool _flashLightOn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flashLight.SetActive(!_flashLightOn);
            _flashLightOn = !_flashLightOn;
            flashLightClick.Play();
        }
    }
}
