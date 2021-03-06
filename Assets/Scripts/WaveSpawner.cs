﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public static WaveSpawner instance;
    public Transform spawnPoint; //The coordinates of the spawn point
    public Transform[] enemyPrefab; //Enemy pref. Make it into array when we have more enemies

    public float spawnRate = 1f; //How often enemies spawn
    public int numOfEnemies = 5; //Number of enemies next wave

    private int enemiesAlive;

    private bool waveInProgress = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            if (gameObject == null)
                Destroy(this);
            else
                Destroy(gameObject);
    }

    /// <summary>
    /// Get called when Start Wave Button is clicked.
    /// </summary>
    /// 
    public void StartWave()
    {
        if (!waveInProgress) {
            waveInProgress = true;
            Tracker.waveCount++;
            StartCoroutine(SpawnWave());
            StartCoroutine(SpawnWave2());
        }
    }

    public void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
            waveInProgress = false;
    }

    /// <summary>
    /// Spawn enemies equal to numOfEnemies.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnWave()
    {
        for(int i = 0 ; i < numOfEnemies + (Tracker.waveCount * 2); i++)
        {
            Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation);
            enemiesAlive++;
            yield return new WaitForSeconds(spawnRate);
        }
             
    }

    IEnumerator SpawnWave2()
    {
        for (int i = 0; i < numOfEnemies + (Tracker.waveCount) - 2; i++)
        {
            Instantiate(enemyPrefab[1], spawnPoint.position, spawnPoint.rotation);
            enemiesAlive++;
            yield return new WaitForSeconds(spawnRate);
        }

    }

}
