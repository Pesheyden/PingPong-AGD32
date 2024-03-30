using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutAnimation : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;
    void Start()
    {
        
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
