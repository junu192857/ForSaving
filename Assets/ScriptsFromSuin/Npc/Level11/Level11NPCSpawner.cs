using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level11NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _kidNPC;
    [SerializeField] private GameObject _bolchieNPC;
    [SerializeField] private GameObject _wizardNPC;
    [SerializeField] private BoundaryData _boundaryData;
    // Start is called before the first frame update
    private float _spawnPeriod = 1.2f; //various depending on level

    Vector3 a = new Vector3(0f, -0.4f, 0f);
    Vector3 b = new Vector3(0f, -1.3f, 0f);

    private Vector3 GetSpawnPosition(int type)
    {
        var ret = Vector3.zero;
        ret.z = -3.0f;
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
        StartCoroutine(SpawnKid());
        StartCoroutine(SpawnBolchie());
        StartCoroutine(SpawnWizard());
    }

    private IEnumerator SpawnKid()
    {
        while (true)
        {   
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_kidNPC, spawnPosition+b,Quaternion.identity);
            npc.GetComponent<Level11KidBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(_spawnPeriod);
        }
        
    }

    private IEnumerator SpawnBolchie()
    {
        yield return new WaitForSeconds(_spawnPeriod * 1/3);
        while (true)
        {
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_bolchieNPC, spawnPosition+a,Quaternion.identity);
            npc.GetComponent<Level11BolchieBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(_spawnPeriod);
        }
    }

    private IEnumerator SpawnWizard()
    {
        yield return new WaitForSeconds(_spawnPeriod * 2/3);
        while (true)
        {
            int spawnpoint = Random.Range(0,6);
            var spawnPosition = GetSpawnPosition(spawnpoint);
            var npc = Instantiate<GameObject>(_wizardNPC, spawnPosition+b,Quaternion.identity);
            npc.GetComponent<Level11WizardBehaviour>().SetDestination(spawnpoint);
            npc.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(_spawnPeriod); 
        }
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
