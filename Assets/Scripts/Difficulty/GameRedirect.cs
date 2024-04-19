using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRedirect : MonoBehaviour
{
    public BallController BallController;
    [SerializeField] private BoardController[] _boardControllers;
    [SerializeField] private BoostManager _boostManager;
    public void ImplementSettings(GameDifficulty gameDifficulty)
    {
        BallController.ImplementSettings(gameDifficulty);
        foreach (BoardController boardController in _boardControllers) 
        { 
            boardController.ImplementSettings(gameDifficulty);
        }
        _boostManager.SettingsImplementation();
    }
}
