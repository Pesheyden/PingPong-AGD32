using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private float _boardSpeed;
    [SerializeField] private float _borders;
    [SerializeField] private string _axisName;

    private BoardManager _boardManager;
    private void Start()
    {
        _boardManager = BoardManager.Instance;
        if (_boardManager.BoardControllers.Count >= 2)
            _boardManager.BoardControllers.Clear();

        _boardManager.BoardControllers.Add(this);
    }
    public void ImplementSettings(GameDifficulty difficulty)
    {
        switch (difficulty)
        {
            case GameDifficulty.Easy:
                DifficultyStats.EasyDifficulty easyDifficultyStats = new();
                transform.localScale *= easyDifficultyStats.BoardSizeMultiplier;
                _boardSpeed *= easyDifficultyStats.BoardSpeedMultiplier;
                break;

            case GameDifficulty.Medium:
                DifficultyStats.MediumDifficulty mediumDifficultyStats = new();
                transform.localScale *= mediumDifficultyStats.BoardSizeMultiplier;
                _boardSpeed *= mediumDifficultyStats.BoardSpeedMultiplier;
                break;

            case GameDifficulty.Hard:
                DifficultyStats.HardDifficulty hardDifficultyStats = new();
                transform.localScale *= hardDifficultyStats.BoardSizeMultiplier;
                _boardSpeed *= hardDifficultyStats.BoardSpeedMultiplier;
                break;
        }
    }

    private void FixedUpdate()
    {
        float ver = Input.GetAxis(_axisName);
        if (((transform.position.y <= _borders && ver >= 0) ||
            (transform.position.y >= -_borders && ver <= 0)) &&
            !_boardManager.IsPaused)
        {
            Movement(ver);
        }
    }

    private void Movement(float axis)
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.up * axis, _boardSpeed);
    }

}
