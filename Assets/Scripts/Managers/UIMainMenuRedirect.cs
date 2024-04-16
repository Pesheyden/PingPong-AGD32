using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuRedirect : MonoBehaviour
{
    private static UIMainMenuRedirect instance;
    public static UIMainMenuRedirect Instance { get { return instance; } }
    
    [SerializeField] private Button _easyDifficultyButton;
    [SerializeField] private Button _mediumDifficultyButton;
    [SerializeField] private Button _hardDifficultyButton;
    [SerializeField] private TextMeshProUGUI _difficultyText;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private void Awake()
    {
        instance = this;

        _easyDifficultyButton.onClick.AddListener( () => ChangeDifficulty(GameDifficulty.Easy));
        _mediumDifficultyButton.onClick.AddListener( () => ChangeDifficulty(GameDifficulty.Medium));
        _hardDifficultyButton.onClick.AddListener( () => ChangeDifficulty(GameDifficulty.Hard));
    }
    private void Start()
    {
        _uiManager = UIManager.Instance;
        _gameManager = GameManager.Instance;
    }
    private void ChangeDifficulty(GameDifficulty difficulty)
    {
        _gameManager.ChangeDifficulty(difficulty);
    }
    public void ChangeDifficultyText(string text, Color color)
    {
        _difficultyText.text = text;
        _difficultyText.color = color;
    }
}
