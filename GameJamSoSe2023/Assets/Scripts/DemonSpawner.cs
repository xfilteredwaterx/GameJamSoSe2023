using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a scipt to spawn demons after some time if the House is Burning
/// </summary>
public class DemonSpawner : MonoBehaviour
{
    //random Min
    public int minSpawnrate;
    public int maxSpawnRate;
    public GameObject demonPrefab;
    
    public int enemyCount;

    private float nextSpawn; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    

    public void SpawnEnemy()
    {
        if (enemyCount<5)
        {
            
            GameObject go =Instantiate(demonPrefab, transform.position, transform.rotation);
            go.GetComponent<NPCStateMachine>().demonSpawner = this;
            nextSpawn = Random.Range(minSpawnrate, maxSpawnRate);
            enemyCount += 1;
        }
        

    }

    private void CheckSpawn()
    {
        if (nextSpawn == 0)
        {
            SpawnEnemy();
        }
    }
}
