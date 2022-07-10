using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{   

    public static Level3Manager Instance {get; private set;}

    public Level3StateManager Level3StateManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Level3StateManager = GetComponentInChildren<Level3StateManager>();
    }
}
   
