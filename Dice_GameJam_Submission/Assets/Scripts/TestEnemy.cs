using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TestEnemy : MonoBehaviour, IKillable
{
    DamageableComponent damageableComponent;
    BoxCollider2D boxCollider;
    [SerializeField] int damagePerHit = 10;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    public void Die() {
        FindObjectOfType<UIScore>().score += 10;
        Destroy(this.gameObject);  
    }
    public void NotifyDamage() { }
}
