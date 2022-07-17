using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] GameObject[] waveOfEnemies1;
    //[SerializeField] GameObject[] waveOfEnemies2;
    //[SerializeField] GameObject[] waveOfEnemies3;
    [SerializeField] GameObject enemy;
    //int currentWave = 1;
    //int waveLimit = 3;
    bool stopSpawning = false;
    private float waitTime = 10f;
    private float minTime = 2f;
    [SerializeField] int enemyLimit = 15;
    private int numberOfEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(waitTime, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        //if (!stopSpawning)
        //{
        //    StartCoroutine(SpawnTimer());
        //}
    }

    //IEnumerator SpawnTimer()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    // Debug.Log("Executing Spawn Enemy Wave");
    //    SpawnEnemyWave();
    //}

    //private void SpawnEnemyWave()
    //{
        //while (!stopSpawning)
        //{

            //switch (currentWave)
            //{
            //    case 1:
            //        // Debug.Log($"spawning wave {currentWave}");
            //        currentWave++;
            //        foreach (GameObject enemy in waveOfEnemies1)
            //        {
            //            SpawnEnemy(enemy);
            //        }
            //        break;
            //    case 2:
            //        // Debug.Log($"spawning wave {currentWave}");
            //        currentWave++;
            //        foreach (GameObject enemy in waveOfEnemies2)
            //        {
            //            SpawnEnemy(enemy);
            //        }
            //        break;
            //    case 3:
            //        // Debug.Log($"spawning wave {currentWave}");
            //        currentWave++;
            //        foreach (GameObject enemy in waveOfEnemies3)
            //        {
            //            SpawnEnemy(enemy);
            //        }
            //        stopSpawning = true;
            //        break;
            //    default: break; //do nothing
            //}
        //}
    //}

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        // Debug.Log($"Number of enemies: {numberOfEnemies}, enemy limit: {ENEMY_LIMIT}");
        if (numberOfEnemies < ENEMY_LIMIT)
        {
            // Debug.Log("Spawning enemy");
            numberOfEnemies++;
            float randomXPosition = Random.Range(-10, 10);
            float randomYPosition = Random.Range(-10, 10);
            var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnEnemy(interval, enemy));
        }
    }
}
