using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRedirect : MonoBehaviour
{
    public BallController BallController;
    public BoardController[] _boardControllers;
    public void ImplementSettings(GameDifficulty gameDifficulty)
    {
        BallController.ImplementSettings(gameDifficulty);
        foreach (BoardController boardController in _boardControllers) 
        { 
            boardController.ImplementSettings(gameDifficulty);
        }
    }
}
