using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11BolchieBehaviour : MonoBehaviour
{
    [SerializeField] private BoundaryData _boundaryData;
    private NpcData _npcData;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    private Animator _animator;

    private bool previousInZoom = false;
    private bool currentlyInZoom = false;

    void Start()
    {
        _npcData = new NpcData(speed: Random.Range(3.0f,5.0f));
        _rigidbody2D = GetComponent<Rigidbody2D>();
        var velocity = _npcData.Speed * (_direction).normalized;
        _rigidbody2D.velocity = (Vector2)velocity;

        _animator = GetComponent<Animator>();
        _animator.SetBool("isRun", true);
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
            Level11Counter.peoplecount++;
            Level11Counter.bolchiecount++;//various
            
        }
        else if (previousInZoom == true && currentlyInZoom == false)
        {
            Level11Counter.peoplecount--;
            Level11Counter.bolchiecount--;//various
            
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Stand - Bat"))
        {
            Debug.Log("Stand");
            
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run - Bat"))
        {
            Debug.Log("Run");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dead - Bat"))
        {
            Debug.Log("Dead");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dead - Idle - Bat"))
        {
            Debug.Log("Dead Idle");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump and Land - Bat"))
        {
            Debug.Log("Jump and Land");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt - Bat"))
        {
            Debug.Log("Hurt");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack - Bat"))
        {
            Debug.Log("Attack Bat");
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack - Bat2"))
        {
            Debug.Log("Attack Bat2");
        }
    }

    public void SetDestination(int spawnpoint)
    {
        if (0 <= spawnpoint && spawnpoint <= 2)
        {
            _direction = new Vector3(1f, 0f, 0f);
            transform.localScale = new Vector3(0.25f, 0.25f, 1f);
        }
        else
        {
            _direction = new Vector3(-1f, 0f, 0f);
            transform.localScale = new Vector3(-0.25f,0.25f,1f);
        }
    }
}

