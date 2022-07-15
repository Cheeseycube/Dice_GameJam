using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour, IKillable
{
    Rigidbody2D rb;
    PolygonCollider2D bodyCollider;
    DamageableComponent damageableComponent;
    float horizontalInput;
    float verticalInput;
    float angle = 0f;

    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private int maxHealth = 100;
    public static bool PlayerDead = false;
    private GameObject damageLight;

    void Start()
    {
        damageableComponent = this.gameObject.AddComponent<DamageableComponent>() as DamageableComponent;
        rb = GetComponent<Rigidbody2D>();
        damageableComponent.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        move();
        rotatePlayer();
    }

    private void move()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
    }

    private void rotatePlayer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void Die()
    {
        PlayerDead = true;
    }

    public void NotifyDamage()
    {
        StartCoroutine(DamageLightToggle());
    }

    IEnumerator DamageLightToggle()
    {
        damageLight.SetActive(true);
        yield return new WaitForSeconds(.5f);
        damageLight.SetActive(false);
    }
}
