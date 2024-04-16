using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour 
{
    private static BoardManager instance;
    public static BoardManager Instance { get { return instance; } }
    public bool IsPaused;
    public List<BoardController> BoardControllers;

    private void Awake()
    {
        instance = this;
    }
}
