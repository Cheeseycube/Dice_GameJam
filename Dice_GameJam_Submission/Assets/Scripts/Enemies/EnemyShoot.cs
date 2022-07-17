using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    private GameObject targetPlayer;
    private float TimeSinceFire = 0f;
    [SerializeField] private bool CanSeePlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetLineOfSight();
        FireGun();
    }

    public bool GetLineOfSight()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, targetPlayer.transform.position - transform.position);
        if (ray.collider.gameObject.CompareTag("Player"))
        {
            CanSeePlayer = true;
            return true;
        }
        else
        {
            CanSeePlayer = false;
            return false;
        }
        return true;
    }

    private void FireGun()
    {
        TimeSinceFire += Time.deltaTime;
        if (TimeSinceFire >= 3f && CanSeePlayer == true)
        {

            TimeSinceFire = 0f;
            Instantiate(enemyBulletPrefab, transform.position, transform.rotation).GetComponent<EnemyProjectileComponent>().Initialize((targetPlayer.transform.position - transform.position).normalized);
        }
    }
}
