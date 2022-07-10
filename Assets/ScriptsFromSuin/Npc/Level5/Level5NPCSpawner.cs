using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level5NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _redBirdNPC;
    [SerializeField] private GameObject _pinkBirdNPC;
    [SerializeField] private GameObject _blueBirdNPC;
    [SerializeField] private BoundaryData _boundaryData;
    // Start is called before the first frame update
    private float _spawnPeriod = 2.5f; //various depending on level


    private Vector3 GetSpawnPosition(int type)
    {
        var ret = Vector3.zero;
        switch(type)
        {
            case 0:
                ret.x = _boundaryData.left;
                ret.y = _boundaryData.floor1;
                break;
            case 1:
                ret.x = _boundaryData.left;
                ret.y = _boundaryData.floor2;
                break;
            case 2:
                ret.x = _boundaryData.left;
                ret.y = _boundaryData.floor3;
                break;
            case 3:
                ret.x = _boundaryData.right;
                ret.y = _boundaryData.floor1;
                break;
            case 4:
                ret.x = _boundaryData.right;
                ret.y = _boundaryData.floor2;
                break;
            case 5:
                ret.x = _boundaryData.right;
                ret.y = _boundaryData.floor3;
                break;
            default:
                break;
        }
        return ret;
    }


    private void Start()
    {
        StartCoroutine(SpawnRedBird());
        StartCoroutine(SpawnPinkBird());
        StartCoroutine(SpawnBlueBird());
    }

    private IEnumerator SpawnRedBird()
    {
        while (true)
        {   
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_redBirdNPC,spawnPosition,Quaternion.identity);
            npc.GetComponent<Level5RedBirdBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(_spawnPeriod);
        }
        
    }

    private IEnumerator SpawnPinkBird()
    {
        yield return new WaitForSeconds(_spawnPeriod * 1/3);
        while (true)
        {
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_pinkBirdNPC,spawnPosition,Quaternion.identity);
            npc.GetComponent<Level5PinkBirdBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(_spawnPeriod);
        }
    }

    private IEnumerator SpawnBlueBird()
    {
        yield return new WaitForSeconds(_spawnPeriod * 2/3);
        while (true)
        {
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_blueBirdNPC,spawnPosition,Quaternion.identity);
            npc.GetComponent<Level5BlueBirdBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(_spawnPeriod); 
        }
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
