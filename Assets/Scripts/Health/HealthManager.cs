using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _playerIndex;
    [SerializeField] private int _damage;
    //[SerializeField] private KeyCode Lost;   Для перевірки
    public static int Loser;

    public delegate void GameOverDelegate(PlayerEnum c);

    public static event GameOverDelegate GameOver;
    
    public enum PlayerEnum
    {
        left = 1,
        right = 2
    }

    void Awake()
    {
        _healthbar.maxValue = _maxHealth;
        _healthbar.value = _maxHealth;
        //GameOver += GameEnded;    Для перевірки 
    }

    void Update()
    {
        if(_healthbar.value <= 0)
        //if (Input.GetKeyDown(Lost))    Для перевірки
        {
            Loser = _playerIndex;
            GameOver?.Invoke((PlayerEnum)_playerIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ChangeHealth(-_damage);
    }

    public void GameEnded(PlayerEnum lost)   //  Для перевірки
    {
        Debug.Log("Player " + lost + " has lost");
    }

    public void ChangeHealth(int health)
    {
        _healthbar.value = health;
    }
}
