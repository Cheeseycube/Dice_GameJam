using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject healthpack;
    [SerializeField] int healthpackLimit = 4;
    [SerializeField] private float waitTime = 5f;
    public int numHealthPacks = 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
            float randomXPosition = Random.Range(-10, 10) + player.transform.position.x;
            float randomYPosition = Random.Range(-10, 10) + player.transform.position.y;
            var spawnPosition = new Vector3(randomXPosition, randomYPosition, 0);
            GameObject newEnemy = Instantiate(healthpack, spawnPosition, Quaternion.identity);
            StartCoroutine(SpawnHealthPack());
        }
    }
}
