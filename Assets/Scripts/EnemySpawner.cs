using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfig currentWave;

    [SerializeField] bool isLooping;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves()
    {

        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position
                     , Quaternion.Euler(0, 0, 180),
                    transform);
                    yield return new WaitForSeconds(currentWave.getSpawnRandomTime());

                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        }
        while (isLooping);


    }

    void Update()
    {

    }
}
