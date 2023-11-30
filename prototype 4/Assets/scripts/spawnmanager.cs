using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 9;
    public int waveNumber = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUp, generatespawnpos(), powerUp.transform.rotation);
    }

   void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++; 
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUp, generatespawnpos(), powerUp.transform.rotation);
        }
    }
 void SpawnEnemyWave( int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i ++) 
        {
            Instantiate(enemyPrefab, generatespawnpos(), enemyPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    private Vector3 generatespawnpos()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx,0, spawnPosz);
        return randomPos;
    }
   
}
