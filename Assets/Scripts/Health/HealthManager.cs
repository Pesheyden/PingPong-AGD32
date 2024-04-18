using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void GameOverDelegate(BallController.Side side);
public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private int _maxHealth;
    [SerializeField] private BallController.Side _playerSide;
    [SerializeField] private int _damage;
    private GameManager _gameManager;
    //[SerializeField] private KeyCode Lost;   Для перевірки


    public static event GameOverDelegate GameOver;
    


    void Awake()
    {
        _healthbar.maxValue = _maxHealth;
        _healthbar.value = _maxHealth;
        //GameOver += GameEnded;    Для перевірки 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.Instance.RespawnBall();
        ChangeHealth(_damage);
        if (_healthbar.value <= 0)
        {
            GameOver(_playerSide);
            return;
        }
    }
    public void ChangeHealth(int health)
    {
        _healthbar.value -= health;
    }
}
