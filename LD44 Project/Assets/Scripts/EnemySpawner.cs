using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// EnemySpawner class - A simple class that spawns enemies based on a ScriptableWave object.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject room;
    [SerializeField] ScriptableWave wave;

    Vector3 topR, bottomL, bufferVector;
    bool canSpawn = true;
    int waveIndex = 0, enemyCount = 1;

    /// <summary>
    /// Get the bounds of the box spawning area by searching for objects with the tags TopRight and BottomLeft.
    /// </summary>
    void Start()
    {
        topR = GameObject.FindGameObjectWithTag("TopRight").gameObject.transform.position;
        bottomL = GameObject.FindGameObjectWithTag("BottomLeft").gameObject.transform.position;
    }

    void Update()
    {
        if (canSpawn)
            StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        if (waveIndex > wave.GetEnemiesToSpawn() - 1) // If the end of the list was reached: Destroy myself.
        {
            Destroy(gameObject);
        }
        canSpawn = false;
        bufferVector.Set(Random.Range(bottomL.x, topR.x), Random.Range(bottomL.y, topR.y), 0);
        Instantiate(wave.GetEnemy(waveIndex), bufferVector, Quaternion.identity); // Spawn the enemy
        enemyCount++; // Count number of the spawned enemies
        yield return new WaitForSeconds(wave.GetSpawnInterval(waveIndex)); // Wait for the time delay for the spawned enemy
        
        if (enemyCount > wave.GetSpawnAmount(waveIndex)) // If the required number of enemies was spawned: Advance in the list
        {
            waveIndex++;
            enemyCount = 1;
        }

        canSpawn = true;
    }
}
