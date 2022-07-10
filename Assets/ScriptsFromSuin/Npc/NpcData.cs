using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class NpcData
{
    private float _speed;

    public float Speed => _speed;

    public NpcData(float speed){
        _speed = speed;
    }
}
