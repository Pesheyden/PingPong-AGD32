using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public delegate void TimerDelegate(string time, string formattedTime);
public class Timer
{
    public float CurrentTime { get; private set; } 
    public string FormattedTime { get; private set; }
    private Coroutine timerCoroutine; 
    public void StartTimer(TimerDelegate func)
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = CoroutineHandler.Instance.StartCoroutine(UpdateTimer(func));
        }
    }
    public void PauseTimer()
    {
        if (timerCoroutine != null)
        {
            CoroutineHandler.Instance.StopCoroutine(timerCoroutine);
        }
    }
    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            CoroutineHandler.Instance.StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
    private IEnumerator UpdateTimer(TimerDelegate func = null)
    {
        CurrentTime = 0f;
        while (true)
        {
            CurrentTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(CurrentTime / 60f);
            int seconds = Mathf.FloorToInt(CurrentTime % 60f);
            FormattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            func(CurrentTime.ToShortString(5), FormattedTime);
            yield return null; 
        }
        
    }
}
public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler instance;
    public static CoroutineHandler Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("CoroutineHandler");
                instance = obj.AddComponent<CoroutineHandler>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
