using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Manager : MonoBehaviour
{   

    public static Level5Manager Instance {get; private set;}

    public Level5StateManager Level5StateManager {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Level5StateManager = GetComponentInChildren<Level5StateManager>();
    }
}
   
