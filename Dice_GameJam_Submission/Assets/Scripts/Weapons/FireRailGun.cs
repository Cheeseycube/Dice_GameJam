using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRailGun : MonoBehaviour
{
    BoxCollider2D gunCol;
    SpriteRenderer myrend;
    Animator myanim;

    private float timer = 0f;
    [SerializeField] private ParticleSystem ChargeParticles;
    [SerializeField] private Animator ChargeAnimator;
    [SerializeField] private SpriteRenderer ChargeSprite;
    [SerializeField] private AudioClip fireSound;

    [SerializeField] int damagePerHit = 150;

    private bool mayFire = true;
    // Start is called before the first frame update
    void Start()
    {
        myrend = GetComponent<SpriteRenderer>();
        myrend.enabled = false;
        myanim = GetComponent<Animator>();
        gunCol = GetComponent<BoxCollider2D>();
        gunCol.enabled = false;
        //myanim.keepAnimatorControllerStateOnDisable = false;
    }


    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    private void FireGun()
    {
        if (Input.GetMouseButton(0) && mayFire)
        {
            // start charging
            ChargeSprite.enabled = true;
            ChargeAnimator.SetBool("Begin Charging", true);
            timer += Time.deltaTime;
            if ((timer >= 1f))
            {
                // charging finished
                ChargeSprite.enabled = false;
                ChargeAnimator.SetBool("Begin Charging", false);
                mayFire = false;
                gunCol.enabled = true;
                myrend.enabled = true;
                myanim.SetBool("RailGunFire", true);
                AudioSource.PlayClipAtPoint(fireSound, this.transform.position);
                StartCoroutine(ShotDuration());
                //StartCoroutine(FireRepeatTimer());
                //StartCoroutine(ChargeUptimer());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            // charging canceled
            timer = 0f;
            ChargeSprite.enabled = false;
            ChargeAnimator.SetBool("Begin Charging", false);
        }

    }

    IEnumerator ShotDuration()
    {
        yield return new WaitForSeconds(0.5f);
        gunCol.enabled = false;
        myrend.enabled = false;
        myanim.SetBool("RailGunFire", false);
        StartCoroutine(FireRepeatTimer());
    }

   IEnumerator FireRepeatTimer()
    {
        yield return new WaitForSeconds(1f);
        mayFire = true;
        timer = 0f;
    }

    public void Set_mayFire(bool FireBool)
    {
        mayFire = FireBool;
    }

    public void ResetAnimation()
    {
        myanim.SetBool("RailGunFire", false);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<DamageableComponent>(out DamageableComponent target))
        {
            target.TakeDamage(damagePerHit);
        }

    }
}
