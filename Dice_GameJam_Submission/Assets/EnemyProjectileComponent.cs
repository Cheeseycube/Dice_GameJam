using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileComponent : MonoBehaviour
{
    [SerializeField] int damagePerHit = 25;
    [SerializeField] GameObject FirePoint;
    [SerializeField] float projectileSpeed = .6f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0f, 0f, FirePoint.transform.rotation.z));
        StartCoroutine(lifetimer());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<DamageableComponent>(out DamageableComponent toDamage))
        {
            toDamage.TakeDamage(damagePerHit);
        }
        Destroy(gameObject);
    }

    public void Initialize(Vector2 fireDir)
    {
        this.transform.right = fireDir;
    }

    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}