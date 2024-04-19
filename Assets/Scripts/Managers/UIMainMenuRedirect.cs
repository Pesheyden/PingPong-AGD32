using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenuRedirect : MonoBehaviour
{
    private static UIMainMenuRedirect instance;
    public static UIMainMenuRedirect Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TextMeshProUGUI _difficultyText;
    public void ChangeDifficulty(int index)
    {
        GameDifficulty gameDifficulty = (GameDifficulty)index;
        GameManager.Instance.ChangeDifficulty(gameDifficulty);
    }
    public void ChangeDifficultyText(string text, Color color)
    {
        _difficultyText.text = text;
        _difficultyText.color = color;
    }
    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
