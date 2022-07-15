using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRailGun : MonoBehaviour
{
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
            print("fire!");
        }
    }
}
