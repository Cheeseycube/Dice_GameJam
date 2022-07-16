using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_FireBall : MonoBehaviour
{
    [SerializeField] private GameObject fire_ball_prefab;

    private bool mayshoot = true;
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
        if (Input.GetMouseButtonDown(0) && mayshoot)
        {
            Instantiate(fire_ball_prefab, transform.position, transform.rotation);
            mayshoot = false;
            StartCoroutine(FireRepeatTimer());
        }
    }

    public void Set_mayFire(bool FireBool)
    {
        mayshoot = FireBool;
    }

    IEnumerator FireRepeatTimer()
    {
        yield return new WaitForSeconds(0.5f);
        mayshoot = true;
    }
}
