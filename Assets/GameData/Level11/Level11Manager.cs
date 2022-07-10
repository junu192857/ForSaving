using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Manager : MonoBehaviour
{   

    public static Level11Manager Instance {get; private set;}

    public Level11StateManager Level11StateManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Level11StateManager = GetComponentInChildren<Level11StateManager>();
    }
}
   
