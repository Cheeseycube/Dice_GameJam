using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    ParticleSystem ExplosionParticles;
    SpriteRenderer myrend;
    BoxCollider2D myCollider;
    CircleCollider2D explosionCol;
    [SerializeField] private GameObject FirePoint;
    [SerializeField] int damagePerHit = 100;

    private float moveSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        explosionCol = GetComponent<CircleCollider2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myrend = GetComponent<SpriteRenderer>();
        ExplosionParticles = GetComponent<ParticleSystem>();
        transform.Rotate(new Vector3(0f, 0f, FirePoint.transform.rotation.z));
        StartCoroutine(lifetimer());
        explosionCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        transform.Translate(Vector2.right * moveSpeed);
    }

    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.TryGetComponent<DamageableComponent>(out DamageableComponent target)) && (!collision.CompareTag("Player")) )
        {
            target.TakeDamage(damagePerHit);
        }

        
        if (!collision.CompareTag("Player"))
        {
            StartCoroutine(DestroyItself());
        }

    }

    IEnumerator DestroyItself()
    {
        Destroy(myrend);
        Destroy(myCollider);
        ExplosionParticles.Play();
        explosionCol.enabled = true;
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
