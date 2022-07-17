using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireMachineGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject FirePoint;
    [SerializeField] public Light2D MuzzleFlashLight;
    [SerializeField] private AudioClip fireSound;

    private bool mayshoot = true;


    private void FixedUpdate()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButton(0))
        {
            spawnBullet();
            StartCoroutine(MuzzleFlashTimer());
        }
    }

    private void spawnBullet()
    {
        if (mayshoot)
        {
            AudioSource.PlayClipAtPoint(fireSound, this.transform.position);
            mayshoot = false;
            Instantiate(bulletPrefab, FirePoint.transform.position, FirePoint.transform.rotation);
            StartCoroutine(FireRateTimer());

        }
    }

    public void Set_mayFire(bool FireBool)
    {
        mayshoot = FireBool;
    }

    IEnumerator FireRateTimer()
    {
        yield return new WaitForSeconds(0.1f);
        mayshoot = true;
    }

    IEnumerator MuzzleFlashTimer()
    {
        MuzzleFlashLight.enabled = true;
        yield return new WaitForSeconds(0.05f);
        MuzzleFlashLight.enabled = false;
    }
}
