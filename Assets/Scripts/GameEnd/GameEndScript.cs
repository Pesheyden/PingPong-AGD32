using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject winPanelLeft;
    public TextMeshProUGUI winPanelLeftText;
    public GameObject winPanelRight;
    public TextMeshProUGUI winPanelRightText;
    public BallMovementHandler ballMovementHandler;
    public BoardController boardControllerLeft;
    public BoardController boardControllerRight;

    private const string recordKey = "BestTime";
    void Start()
    {
        winPanelLeft.SetActive(false);
        winPanelRight.SetActive(false);
        HealthManager.GameOver += GameOver;
    }
    public void GameOver(BallController.Side winner)
    {

        ballMovementHandler.BlockBall();
        boardControllerLeft.enabled = false;
        boardControllerRight.enabled = false;
        float bestTime = 0;
        float currentTime = GameManager.Instance.Timer.CurrentTime;
        if(DataManager.Instance.LoadData(recordKey) != null)
            bestTime = JsonUtility.FromJson<float>(DataManager.Instance.LoadData(recordKey));

        if (currentTime > bestTime)
        {
            string jsonData = JsonUtility.ToJson(currentTime);
            DataManager.Instance.SaveData(recordKey, jsonData);
        }
        GameManager.Instance.StopGameTimer();
        if (winner == BallController.Side.Left)
        {
            winPanelLeft.SetActive(true);
            winPanelLeftText.text = GameManager.Instance.Timer.FormattedTime.ToString();
        }
        else
        {
            winPanelRight.SetActive(true);
            winPanelRightText.text = GameManager.Instance.Timer.FormattedTime.ToString();
        }
    }
}
