using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject FirePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }
}
