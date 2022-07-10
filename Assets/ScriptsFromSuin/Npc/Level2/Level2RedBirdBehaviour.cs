using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level2RedBirdBehaviour : MonoBehaviour
{
    [SerializeField] private BoundaryData _boundaryData;
    private NpcData _npcData;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;

    private bool previousInZoom = false;
    private bool currentlyInZoom = false;

    void Start()
    {
        _npcData = new NpcData(speed: Random.Range(2.0f,4.0f));
        _rigidbody2D = GetComponent<Rigidbody2D>();
        var velocity = _npcData.Speed * (_direction).normalized;
        _rigidbody2D.velocity = (Vector2)velocity;
    }

    private void Update()
    {
        var pos = transform.position;
        var isInBoundary = (_boundaryData.xMin - 1 < pos.x && pos.x < _boundaryData.xMax +1);

        if (isInBoundary == false){
            Destroy(gameObject);
        }
        previousInZoom = currentlyInZoom;
        currentlyInZoom = (-5.3f < pos.x && pos.x < 5.3f) ? true : false;

        if (previousInZoom == false && currentlyInZoom == true)
        {
            Level2Counter.birdcount++;
            Debug.Log($"Counter added. current count:{Level2Counter.birdcount}");
            
        }
        else if (previousInZoom == true && currentlyInZoom == false)
        {
            Level2Counter.birdcount--;
            Debug.Log($"Counter substracted. current count:{Level2Counter.birdcount}");
        }

    }

    public void SetDestination(int spawnpoint)
    {
        if (0 <= spawnpoint && spawnpoint <= 2)
        {
            _direction = new Vector3(1f, 0f, 0f);
        }
        else
        {
            _direction = new Vector3(-1f, 0f, 0f);
            transform.localScale = new Vector3(-0.3f,0.3f,1f);
        }
    }

 
    
    
}

