using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private EnemySpawner _waveSpawner;

    private void Awake()
    {
        _waveSpawner = GameObject.Find("Spawner Parent").GetComponent<EnemySpawner>();
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
            _waveSpawner.LaunchWave();
    }
}
