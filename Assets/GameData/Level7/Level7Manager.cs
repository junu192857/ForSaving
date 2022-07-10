using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7Manager : MonoBehaviour
{   

    public static Level7Manager Instance {get; private set;}

    public Level7StateManager Level7StateManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Level7StateManager = GetComponentInChildren<Level7StateManager>();
    }
}
   
