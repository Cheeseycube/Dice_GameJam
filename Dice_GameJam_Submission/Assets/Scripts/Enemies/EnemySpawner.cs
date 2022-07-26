using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject enemyType;
    
    [SerializeField] private float waitTime = 10f;
    [SerializeField] private float minWaitTime = 2f;
    [SerializeField] private float minDistanceAway = 5f;

    [SerializeField] private int enemyLimit = 100;
    private int numberOfEnemies = 0;


    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SpawnEnemy(enemyType));
        StartCoroutine(DecreaseSpawnTime());
    }


    private IEnumerator DecreaseSpawnTime()
    {
        yield return new WaitForSeconds(20);
        if(waitTime > minWaitTime)
        {
            waitTime -= 1f;
        }
        StartCoroutine(DecreaseSpawnTime());
    }
 
    
    // should not spawn within 5 paces of the player
    private IEnumerator SpawnEnemy(GameObject enemyType)
    {
        yield return new WaitForSeconds(waitTime);
        if (numberOfEnemies < enemyLimit)
        {
            numberOfEnemies++;
            float randomXPosition = Random.Range(-10, 10) + player.transform.position.x;
            float randomYPosition = Random.Range(-10, 10) + player.transform.position.y;
            //var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            var spawnPosition = CreateRandomCoordinates();
            //GameObject newEnemy = Instantiate(enemyType, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnWait(enemyType));
            StartCoroutine(SpawnEnemy(enemyType));
        }
    }

    private IEnumerator SpawnWait(GameObject enemyType)
    {
        yield return new WaitForSeconds(2f);
    }

    // Returns a set of random coordinates that are at least 5 away from the player
    private Vector3 CreateRandomCoordinates()
    {
        // creates a random position between -10 and 10
        float randomXPosition = Random.Range(-10, 11) + player.transform.position.x;
        float randomYPosition = Random.Range(-10, 11) + player.transform.position.y;
        // Checks if the random position is less than the min distance away, then adds the difference if needed
        float Difference = minDistanceAway - Math.Abs(randomXPosition);
        if (Difference > 0)
        {
            randomXPosition += Difference;
        }
        Difference = minDistanceAway - Math.Abs(randomYPosition);
        if (Difference > 0)
        {
            randomYPosition += Difference;
        }
        return new Vector3(randomXPosition, randomYPosition, 0);
    }
}
