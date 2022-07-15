using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject FirePoint;

    private bool mayshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButton(0))
        {
            spawnBullet();
        }
    }

    private void spawnBullet()
    {
        if (mayshoot)
        {
            mayshoot = false;
            Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
            StartCoroutine(FireRateTimer());

        }
    }

    IEnumerator FireRateTimer()
    {
        yield return new WaitForSeconds(0.1f);
        mayshoot = true;
    }
}
