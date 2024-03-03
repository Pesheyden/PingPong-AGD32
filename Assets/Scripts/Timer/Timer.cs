using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float CurrentTime { get; private set; } 
    public string FormattedTime { get; private set; }
    private Coroutine timerCoroutine; 
    public void StartTimer()
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = CoroutineHandler.Instance.StartCoroutine(UpdateTimer());
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
    private IEnumerator UpdateTimer()
    {
        CurrentTime = 0f;
        while (true)
        {
            CurrentTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(CurrentTime / 60f);
            int seconds = Mathf.FloorToInt(CurrentTime % 60f);
            FormattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
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
