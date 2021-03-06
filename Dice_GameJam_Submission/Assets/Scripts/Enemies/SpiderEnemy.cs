using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour, IKillable
{
    DamageableComponent damageableComponent;
    BoxCollider2D boxCollider;
    [SerializeField] int damagePerHit = 35;
    [SerializeField] private NavMeshAgent navMeshobj;
    [SerializeField] private GameObject damageLight;
    [SerializeField] private int maxHealth = 200;
    [SerializeField] private AudioClip damageSound;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableComponent = this.gameObject.AddComponent<DamageableComponent>();
        damageableComponent.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        //FlipSprite();
    }

    private void FlipSprite()
    {
        if (navMeshobj.velocity.x < 0)
        {
            transform.localScale = new Vector2(2, gameObject.transform.localScale.y);
        }
        else if (navMeshobj.velocity.x > 0)
        {
            transform.localScale = new Vector2(-2, gameObject.transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<DamageableComponent>(out DamageableComponent target))
        {
            target.TakeDamage(damagePerHit);
        }
    }

    public void Die()
    {
        FindObjectOfType<UIScore>().score += 10;
        Destroy(this.gameObject);
    }
    public void NotifyDamage()
    {
        AudioSource.PlayClipAtPoint(damageSound, this.gameObject.transform.position);
        StartCoroutine(DamageLightToggle());
    }

    IEnumerator DamageLightToggle()
    {
        damageLight.SetActive(true);
        yield return new WaitForSeconds(.5f);
        damageLight.SetActive(false);
    }
}
