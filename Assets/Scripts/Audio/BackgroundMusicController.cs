using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public GameObject[] activeObjects; 

    private AudioSource backgroundMusic; 
    private bool musicPlaying = false; 

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>(); 
        backgroundMusic.Play(); 
        musicPlaying = true;
    }

    void Update()
    {
        bool anyActive = false; 

        
        foreach (GameObject obj in activeObjects)
        {
            
            if (obj.activeSelf)
            {
                anyActive = true;
                break;
            }
        }

        
        if (anyActive && musicPlaying)
        {
            backgroundMusic.Pause();
            musicPlaying = false;
        }
        
        else if (!anyActive && !musicPlaying)
        {
            backgroundMusic.Play();
            musicPlaying = true;
        }
    }
}
