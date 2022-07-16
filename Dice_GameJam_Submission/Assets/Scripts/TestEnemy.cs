using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IKillable
{
    DamageableComponent damageableComponent;
    BoxCollider2D boxCollider;
    [SerializeField] int damagePerHit = 10;

    // Start is called before the first frame update
    void Start()
    {
        damageableComponent = this.gameObject.AddComponent<DamageableComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<DamageableComponent>(out DamageableComponent target))
        {
            target.TakeDamage(damagePerHit);
        }
    }

    public void Die() { Destroy(this.gameObject);  }
    public void NotifyDamage() { }
}
