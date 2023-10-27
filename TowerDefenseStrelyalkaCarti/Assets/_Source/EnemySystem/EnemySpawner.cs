using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemyTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(enemyTime, enemyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(float time, GameObject enemy)
    {
        yield return new WaitForSeconds(time);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), Random.Range(-11f, 11f), 0), Quaternion.identity);
        StartCoroutine(Spawn(time, enemy));
    }
}
