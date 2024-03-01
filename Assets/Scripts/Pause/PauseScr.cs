using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScr : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] string mainMenuSceneName;
    [Header("Buttons")]
    [SerializeField] Button pauseButton;
    [SerializeField] Button backToMenuButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;
    [Header("Paused Objects")]
    [SerializeField] BoardController leftBoard;
    [SerializeField] BoardController rightBoard;
    //[SerializeField] ball is gonna be here

    bool isPaused = false;

    void Start(){
        pauseButton     .onClick.AddListener(() => PauseGame());
        continueButton  .onClick.AddListener(() => PauseGame());
        restartButton   .onClick.AddListener(() => { isPaused = false; LoadScene(SceneManager.GetActiveScene().name); });
        backToMenuButton.onClick.AddListener(() => LoadScene(mainMenuSceneName));
    }

    void LoadScene(string sceneName) { SceneManager.LoadScene(sceneName); }

    void PauseGame(){
        print(isPaused);
        leftBoard.enabled = isPaused;
        rightBoard.enabled = isPaused;
        // Ball pause will depend on how its physics work

        // Require reversed value as "isPaused" ↑↑↑
        isPaused = !isPaused;
        // Require same value as "isPaused"     ↓↓↓
        
        pauseMenu.SetActive(isPaused);
    }





}
