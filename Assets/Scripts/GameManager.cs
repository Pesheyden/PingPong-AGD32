using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallController _ballController;
    public void RespawnBall()
    {
        _ballController.SpawnBall();
    }
}
