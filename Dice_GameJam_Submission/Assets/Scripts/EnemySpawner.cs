using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] enemies;
    
    private float waitTime = 10f;
    private float minTime = 2f;
    private const int ENEMY_LIMIT = 50;
    private int numberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(enemy));
        StartCoroutine(DecreaseSpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator DecreaseSpawnDelay()
    {
        yield return new WaitForSeconds(10f);

        if (waitTime > minTime)
        {
            Debug.Log($"Decreasing waittime");
            Debug.Log($"old waittime: {waitTime}");
            waitTime--;
            Debug.Log($"new waittime: {waitTime}");
        }
        StartCoroutine(DecreaseSpawnDelay());
    }

    private IEnumerator SpawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(waitTime);
        
        if (numberOfEnemies < ENEMY_LIMIT)
        {
            numberOfEnemies++;
            float randomXPosition = Random.Range(-10, 10);
            float randomYPosition = Random.Range(-10, 10);
            var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnEnemy(enemy));
        }
    }
}
