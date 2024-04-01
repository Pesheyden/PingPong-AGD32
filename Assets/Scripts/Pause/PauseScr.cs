using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScr : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName;

    [Header("Player Green")]
    [SerializeField] GameObject g_Menu;
    [SerializeField] Button g_tryagain;
    [SerializeField] Button g_mainmenu;

    [Header("Player Pink")]
    [SerializeField] GameObject p_Menu;
    [SerializeField] Button p_tryagain;
    [SerializeField] Button p_mainmenu;

    [Header("Pause")]
    [SerializeField] GameObject pause_Menu;
    [SerializeField] Button pause_button;
    [SerializeField] Button pause_mainmenu;
    [SerializeField] Button pause_continue;
    [SerializeField] Button pause_tryagain;

    [Header("Paused Objects")]
    [SerializeField] BoardController leftBoard;
    [SerializeField] BoardController rightBoard;
    [SerializeField] BallController  ballController;

    bool isPaused = false;

    void Start(){
        pause_continue.onClick.AddListener(() => PauseGame());
        pause_button  .onClick.AddListener(() => PauseGame());
        pause_tryagain.onClick.AddListener(() => RestartGame());
        pause_mainmenu.onClick.AddListener(() => GoToMainMenu());

        g_tryagain.onClick.AddListener(() => RestartGame());
        p_tryagain.onClick.AddListener(() => RestartGame());
        
        g_mainmenu.onClick.AddListener(() => GoToMainMenu());
        p_mainmenu.onClick.AddListener(() => GoToMainMenu());
    }

    // void ChangeWinMenuState(int menuIndex)
    void LoadScene(string sceneName) { SceneManager.LoadScene(sceneName); }
    void RestartGame()  { isPaused = false; LoadScene(SceneManager.GetActiveScene().name); }
    void GoToMainMenu() { LoadScene(mainMenuSceneName); }

    void PauseGame(){
        if (leftBoard != null)      leftBoard.enabled = isPaused;
        if (rightBoard != null)     rightBoard.enabled = isPaused;
        if (ballController != null) ballController.PauseBallStatusChange(isPaused);

        // Require reversed value as "isPaused" ↑↑↑
        isPaused = !isPaused;
        // Require same value as "isPaused"     ↓↓↓
        
        pause_Menu.SetActive(isPaused);
    }


    // just for testing ↓↓↓↓↓↓↓↓↓
    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) g_Menu.SetActive(!g_Menu.activeSelf);
        if (Input.GetKeyDown(KeyCode.P)) p_Menu.SetActive(!p_Menu.activeSelf);
    }





}
