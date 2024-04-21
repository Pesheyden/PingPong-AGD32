using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _soundClip;
     private AudioSource _audioSource;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _soundClip;
        _audioSource.playOnAwake = false;
        _audioSource.volume = 0.5f;
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_soundClip);
    }
}
