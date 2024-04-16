using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("Instance of UIManager already exists");
        }
    }

    public void ChangeDifficultyText(string text)
    {
        UIMainMenuRedirect.Instance.ChangeDifficultyText(text);
    }
}
