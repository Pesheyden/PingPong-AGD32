using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScr : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] GameObject pause_Menu;


    [Header("Paused Objects")]
    [SerializeField] BoardController leftBoard;
    [SerializeField] BoardController rightBoard;
    [SerializeField] BallController  ballController;

    bool isPaused = false;

    public void PauseGame(){
        if (leftBoard != null)      leftBoard.enabled = isPaused;
        if (rightBoard != null)     rightBoard.enabled = isPaused;


        // Require reversed value as "isPaused" ↑↑↑
        isPaused = !isPaused;
        // Require same value as "isPaused"     ↓↓↓
        if (ballController != null) ballController.PauseBallStatusChange(isPaused);
        pause_Menu.SetActive(isPaused);

        if (isPaused)
        {
            GameManager.Instance.PauseTimer();
        }
        else
        {
            GameManager.Instance.UnPauseTimer();
        }
    }


    // just for testing ↓↓↓↓↓↓↓↓↓
    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.O)) g_Menu.SetActive(!g_Menu.activeSelf);
    //    if (Input.GetKeyDown(KeyCode.P)) p_Menu.SetActive(!p_Menu.activeSelf);
    //}





}
