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

    [SerializeField] int enemyLimit = 100;
    private int numberOfEnemies = 0;


    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyType));
        StartCoroutine(DecreaseSpawnTime());
    }


    private IEnumerator DecreaseSpawnTime()
    {
        yield return new WaitForSeconds(10);
        if(waitTime < minTime)
        {
            waitTime -= 1f;
        }
        StartCoroutine(DecreaseSpawnTime());
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