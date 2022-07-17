using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healthpack;
    [SerializeField] int healthpackLimit = 3;
    [SerializeField] private float waitTime = 5f;
    private int numHealthPacks = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHealthPack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnHealthPack()
    {
        yield return new WaitForSeconds(waitTime);
        if (numHealthPacks < healthpackLimit)
        {
            numHealthPacks++;
            float randomXPosition = Random.Range(-10, 10);
            float randomYPosition = Random.Range(-10, 10);
            var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            GameObject newEnemy = Instantiate(healthpack, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnHealthPack());
        }
    }
}
