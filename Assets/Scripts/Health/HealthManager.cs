using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _playerIndex;
    //[SerializeField] private KeyCode Lost;    Для перевірки
    public static int Loser;

    public static event Action GameOver;
    

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
            GameOver?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DamageTaken();
    }

    private void DamageTaken()
    {
        _healthbar.value --; 
    }

    public void GameEnded() //    Для перевірки
    {
        Debug.Log("Player " + Loser + " has lost");
    }

    public void ChangeHealth(int health)
    {
        _healthbar.value = health;
    }
}
