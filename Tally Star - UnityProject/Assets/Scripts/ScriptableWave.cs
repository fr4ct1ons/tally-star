using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Enemy Wave")]
public class ScriptableWave : ScriptableObject
{
    [SerializeField] GameObject[] enemiesToSpawn;
    [SerializeField] int[] amountToSpawn;
    [SerializeField] float[] timeBetweenSpawn;
    
    public int GetEnemiesToSpawn() { return enemiesToSpawn.Length; }
    public GameObject GetEnemy(int pos) { return enemiesToSpawn[pos]; }
    public float GetSpawnInterval(int pos) { return timeBetweenSpawn[pos]; }
    public int GetSpawnAmount(int pos) { return amountToSpawn[pos]; }
}
