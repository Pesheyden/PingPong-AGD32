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
    private GameDifficulty _gameDifficulty = GameDifficulty.Hard;
    [SerializeField] private Color _easyTextColor = Color.green;
    [SerializeField] private Color _mediumTextColor = Color.yellow;
    [SerializeField] private Color _hardTextColor = Color.red;

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
                StartSettingsImplementation();
                break;
        }
    }
    public void ChangeDifficulty(GameDifficulty difficulty)
    {
        Debug.Log(1);
        if(difficulty == _gameDifficulty) return;
        Debug.Log(2);
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
    public void RespawnBall()
    {
        _ballController.SpawnBall();
    }
    private void StartSettingsImplementation()
    {
        _gameRedirect.ImplementSettings(_gameDifficulty);
    }
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
public enum GameDifficulty
{
    Easy,
    Medium,
    Hard,
}
