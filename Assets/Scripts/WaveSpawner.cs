using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform spawnPoint; //The coordinates of the spawn point
    public Transform enemyPrefab; //Enemy pref. Make it into array when we have more enemies

    public float spawnRate = 1f; //How often enemies spawn
    public int numOfEnemies = 10; //Number of enemies next wave

    /// <summary>
    /// Get called when Start Wave Button is clicked.
    /// </summary>
    public void StartWave()
    {
        Tracker.waveCount++;
        StartCoroutine(SpawnWave());
    }

    /// <summary>
    /// Spawn enemies equal to numOfEnemies.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnWave()
    {
        for(int i=0;i<numOfEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
             
    }

   
}
