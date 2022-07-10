using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{   

    public static Level2Manager Instance {get; private set;}

    public Level2StateManager Level2StateManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Level2StateManager = GetComponentInChildren<Level2StateManager>();
    }
}
   
