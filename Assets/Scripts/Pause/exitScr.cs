using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class exitScr : MonoBehaviour
{
    [SerializeField] Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(() => {print("exited program"); Application.Quit();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
