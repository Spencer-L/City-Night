using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivation : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private GameObject[] _allAudioSources;

    private void Start()
    {
        _allAudioSources = GameObject.FindGameObjectsWithTag("Audio");
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var aud in _allAudioSources)
        {
            aud.SetActive(false);
        }
        audioSource.enabled = true;
    }
}
