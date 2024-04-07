using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    [SerializeField] private AudioClip _soundClip;
    private AudioSource _audioSource;

    [SerializeField] private GameObject _fadeOut;

    [SerializeField] private AudioSource _backgroundMusic;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _soundClip;
        _audioSource.playOnAwake = false;
        _audioSource.volume = 0.4f;
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_soundClip);
    }

    public void FadeOut()
    {
        _fadeOut.SetActive(true);
    }

    public void StopBackgroundMusic()
    {
        _backgroundMusic.Stop();
    }
}
