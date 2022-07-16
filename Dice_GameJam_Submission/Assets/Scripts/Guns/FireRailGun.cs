using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRailGun : MonoBehaviour
{
    BoxCollider2D gunCol;
    SpriteRenderer myrend;
    Animator myanim;
    [SerializeField] private ParticleSystem ChargeParticles;

    private bool mayFire = true;
    // Start is called before the first frame update
    void Start()
    {
        myrend = GetComponent<SpriteRenderer>();
        myrend.enabled = false;
        myanim = GetComponent<Animator>();
        gunCol = GetComponent<BoxCollider2D>();
        gunCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButtonDown(0) && mayFire)
        {
            mayFire = false;
            StartCoroutine(ChargeUptimer());
        }
    }

    IEnumerator ChargeUptimer()
    {
        print("charging!");
        yield return new WaitForSeconds(0.5f);
        gunCol.enabled = true;
        myrend.enabled = true;
        myanim.SetBool("RailGunFire", true);
        StartCoroutine(ShotDuration());
        StartCoroutine(FireRepeatTimer());
    }
    IEnumerator ShotDuration()
    {
        yield return new WaitForSeconds(0.5f);
        gunCol.enabled = false;
        myrend.enabled = false;
        myanim.SetBool("RailGunFire", false);
    }

   IEnumerator FireRepeatTimer()
    {
        yield return new WaitForSeconds(1f);
        mayFire = true;
    }
}
