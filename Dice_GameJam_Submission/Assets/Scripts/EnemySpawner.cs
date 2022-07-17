using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyType;
    
    private float waitTime = 10f;
    private float minTime = 2f;
    [SerializeField] int enemyLimit = 15;
    private int numberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyType));
        StartCoroutine(DecreaseSpawnDelay());
    }

    private IEnumerator DecreaseSpawnDelay()
    {
        yield return new WaitForSeconds(10f);

        if (waitTime > minTime)
        {
            waitTime--;
        }
        StartCoroutine(DecreaseSpawnDelay());
    }

    private IEnumerator SpawnEnemy(GameObject enemyType)
    {
        yield return new WaitForSeconds(waitTime);
        
        if (numberOfEnemies < enemyLimit)
        {
            numberOfEnemies++;
            float randomXPosition = Random.Range(-10, 10);
            float randomYPosition = Random.Range(-10, 10);
            var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            GameObject newEnemy = Instantiate(enemyType, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnEnemy(enemyType));
        }
    }
}
