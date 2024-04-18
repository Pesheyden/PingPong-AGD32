using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameRedirect : MonoBehaviour
{
    private static UIGameRedirect _instance;

    public static UIGameRedirect Instance 
    { get { return _instance; } }


    [SerializeField] private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateTimerText(string text)
    {
        _timerText.text = text;
    }
}
