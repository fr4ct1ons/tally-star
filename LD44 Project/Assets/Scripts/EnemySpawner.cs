using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject room;
    [SerializeField] ScriptableWave wave;

    Vector2 topR, bottomL, bufferVector;
    bool canSpawn = true;
    int waveIndex = 0, enemyCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
            StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        if (waveIndex > wave.GetEnemiesToSpawn() - 1)
        {
            //Debug.Log("Deleting!");
            //Debug.Log("Deletion Number of enemies to spawn: " + wave.GetEnemiesToSpawn());
            //Debug.Log("Deletion Wave index: " + waveIndex);
            //Debug.Log("Deletion Enemy count: " + enemyCount);
            Destroy(gameObject);
        }
        canSpawn = false;
        Instantiate(wave.GetEnemy(waveIndex));
        enemyCount++;
        yield return new WaitForSeconds(wave.GetSpawnInterval(waveIndex));
        
        if (enemyCount > wave.GetSpawnAmount(waveIndex))
        {
            waveIndex++;
            enemyCount = 1;
        }

        //Debug.Log("Number of enemies to spawn: " + wave.GetEnemiesToSpawn());
        //Debug.Log("Wave index: " + waveIndex);
        //Debug.Log("Enemy count: " + enemyCount);

        canSpawn = true;
    }
}
