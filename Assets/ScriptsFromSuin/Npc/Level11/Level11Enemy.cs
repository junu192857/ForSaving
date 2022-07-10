using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Enemy : MonoBehaviour
{
    SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    

    public void shootenemy()
    {
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor()
    {
        render.color = new Color(1,0,0,1);
        yield return new WaitForSeconds(0.15f);
        render.color = new Color(1,1,1,1);
    }
}