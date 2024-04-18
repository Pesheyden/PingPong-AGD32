using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }



    private UIManager _uiManager;
    private BallController _ballController;


    private GameRedirect _gameRedirect;
    private GameDifficulty _gameDifficulty = GameDifficulty.Easy;
    [SerializeField] private Color _easyTextColor = Color.green;
    [SerializeField] private Color _mediumTextColor = Color.yellow;
    [SerializeField] private Color _hardTextColor = Color.red;


    public Timer Timer = new Timer();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("Instance of GameManager already exists");
        }


        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _uiManager = UIManager.Instance;
        LoadScene(1);
    }
    private void OnLevelWasLoaded(int level)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                ChangeDifficulty(GameDifficulty.Easy);
                break;
            case "Game":
                _gameRedirect = FindObjectOfType<GameRedirect>();
                _ballController = _gameRedirect.BallController;
                StartCoroutine(GameStartWaiter());
                break;
        }
    }
    public void ChangeDifficulty(GameDifficulty difficulty)
    {
        _gameDifficulty = difficulty;
        Color color = Color.white;
        switch (difficulty)
        {
            case GameDifficulty.Easy: color = _easyTextColor; break;
            case GameDifficulty.Medium: color = _mediumTextColor; break;
            case GameDifficulty.Hard: color = _hardTextColor; break;
            default: Debug.LogError($"Color for difficulty {difficulty} is not implemented"); break;
        }
        _uiManager.ChangeDifficultyText(difficulty.ToString(), color);
    }
    public void RestartScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene(index);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    private IEnumerator GameStartWaiter()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        StartGame();
    }
    private void StartGame()
    {
        _ballController.SpawnBall();
        StartSettingsImplementation();
        Timer.StartTimer(GameTimerUpdate);
    }
    public void GameTimerUpdate(string time, string formattedTime)
    {
        UIManager.Instance.UpdateTimerText(formattedTime);
    }
    public void PauseTimer()
    {
        Timer.PauseTimer();
    }
    public void UnPauseTimer()
    {
        Timer.StartTimer(GameTimerUpdate);
    }
    private void StartSettingsImplementation()
    {
        _gameRedirect.ImplementSettings(_gameDifficulty);
    }
    public void RespawnBall()
    {
        _ballController.SpawnBall();
    }
    public void StopGameTimer()
    {
        Timer.StopTimer();
    }
}
[Serializable]
public enum GameDifficulty
{
    Easy = 0,
    Medium = 1,
    Hard = 2,
}
