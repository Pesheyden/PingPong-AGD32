using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip wallHitSound;
    [SerializeField] private AudioClip goalSound;
    [SerializeField] private AudioClip boostPickupSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(collisionLayer);

        switch (layerName)
        {
            case "Walls and boards":
                PlaySound(wallHitSound);
                break;
            case "Goal zone":
                PlaySound(goalSound);
                break;
            case "Boost":
                PlaySound(boostPickupSound);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(collisionLayer);

        switch (layerName)
        {
            case "Boost":
                PlaySound(boostPickupSound);
                break;
            default:
                break;
        }
    }

    private void PlaySound(AudioClip sound)
    {
        if (sound != null && audioSource != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
