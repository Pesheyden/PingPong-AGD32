using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    public GameObject winPanelLeft;
    public GameObject winPanelRight;
    public BallMovementHandler ballMovementHandler;
    public BoardController boardControllerLeft;
    public BoardController boardControllerRight;
    private bool recordBeaten = false;
    private const string recordKey = "BestTime";
    void Start()
    {
        winPanelLeft.SetActive(false);
        winPanelRight.SetActive(false);
    }
    public void GameOver(HealthManager.PlayerEnum winner)
    {
        if (winner == HealthManager.PlayerEnum.left)
        {
            winPanelLeft.SetActive(true);
        }
        else
        {
            winPanelRight.SetActive(true);
        }
        ballMovementHandler.BlockBall();
        boardControllerLeft.enabled = false;
        boardControllerRight.enabled = false;
        float currentTime = Time.time;
        float bestTime = PlayerPrefs.GetFloat(recordKey, Mathf.Infinity);
        if (currentTime < bestTime)
        {
            PlayerPrefs.SetFloat(recordKey, currentTime);
            PlayerPrefs.Save();
            recordBeaten = true;
        }
    }
}
