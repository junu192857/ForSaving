using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BoundaryData", order =1)]

public class BoundaryData : ScriptableObject
{   
    public float xMin;
    public float xMax;
     
    public float left;
    public float right;
    public float floor1;
    public float floor2;
    public float floor3;
}
