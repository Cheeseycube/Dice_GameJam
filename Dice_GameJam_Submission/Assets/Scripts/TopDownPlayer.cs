using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D bodyCollider;
    float horizontalInput;
    float verticalInput;
    float angle = 0f;

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] public static float health = 100f;
    public static bool PlayerDead = false;
    public GameObject damageLight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bodyCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        /*(if (Player.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }*/
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
    public void TakeDamage(float damageDealt)
    {
        health -= damageDealt;
        if (health <= 0f)
        {
            PlayerDead = true;
        }
    }
    public void DamageKick()
    {
        rb.velocity = new Vector2(0f, 30f);
    }
    public void DamageIndicator(bool isDamaged)
    {
        damageLight.SetActive(isDamaged);
    }

}
