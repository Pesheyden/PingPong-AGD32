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
    }
    private void OnLevelWasLoaded(int level)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                break;
            case "Game":
                _gameRedirect = FindObjectOfType<GameRedirect>();
                _ballController = _gameRedirect.BallController;
                StartSettingsImplementation();
                break;
        }
    }
    public void ChangeDifficulty(GameDifficulty difficulty)
    {
        if(difficulty == _gameDifficulty) return;

        _gameDifficulty = difficulty;
        _uiManager.ChangeDifficultyText(difficulty.ToString());
    }
    public void RespawnBall()
    {
        _ballController.SpawnBall();
    }
    private void StartSettingsImplementation()
    {
        _gameRedirect.ImplementSettings(_gameDifficulty);
    }
}
public enum GameDifficulty
{
    Easy,
    Medium,
    Hard,
}
