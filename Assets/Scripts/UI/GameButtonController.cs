using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonController : MonoBehaviour
{
    [SerializeField] private PauseScr _pauseScr;

    public void RestartGame()
    {
        GameManager.Instance.RestartScene();
    }
    public void LoadNextScene()
    {
        GameManager.Instance.LoadNextScene();
    }
    public void LoadScene(int index)
    {
        GameManager.Instance.LoadScene(index);
    }
    public void PauseUnPauseGame()
    {
        _pauseScr.PauseGame();
    }
}
