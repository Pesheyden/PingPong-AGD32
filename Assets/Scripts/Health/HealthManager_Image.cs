using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager_Image : MonoBehaviour
{
    [SerializeField] private Image[] _healthbar;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _playerIndex;
    [SerializeField] private int _damage;
    //[SerializeField] private KeyCode Lost;   ��� ��������
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
        foreach (Image hbar in _healthbar) {hbar.fillAmount = _maxHealth;}
        //GameOver += GameEnded;    ��� �������� 
    }

    void Update()
    {
        if(_healthbar[0].fillAmount <= 0)
        //if (Input.GetKeyDown(Lost))    ��� ��������
        {
            Loser = _playerIndex;
            GameOver?.Invoke((PlayerEnum)_playerIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ChangeHealth_Image(_damage);
    }

    public void GameEnded(PlayerEnum lost)   //  ��� ��������
    {
        Debug.Log("Player " + lost + " has lost");
    }

    public void ChangeHealth_Image(float damage)
    {
        // foreach (Image hbar in _healthbar) {print(hbar.fillAmount + "  /  " + (hbar.fillAmount - (damage / _maxHealth)));}
        foreach (Image hbar in _healthbar) {hbar.fillAmount = hbar.fillAmount - (damage / _maxHealth);}
    }
}
