using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

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
    private bool PlayerDead = false;
    [SerializeField] private GameObject damageLight;

    private GameObject MachineGun;
    private GameObject RailGun;
    private GameObject FireBall;

    SpriteRenderer myrend;
    
    void Start()
    {
        MachineGun = GameObject.Find("Gun_placeholder");
        RailGun = GameObject.Find("Rail_gun placholder");
        FireBall = GameObject.Find("FireBall");

        myrend = GetComponent<SpriteRenderer>();
        damageableComponent = this.gameObject.AddComponent<DamageableComponent>() as DamageableComponent;
        rb = GetComponent<Rigidbody2D>();
        damageableComponent.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //print(PlayerDead);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (PlayerDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        //Time.timeScale = 0;
        //MachineGun.SetActive(false);
        //RailGun.SetActive(false);
        //FireBall.SetActive(false);
        PlayerDead = true;
        FindObjectOfType<GameManager>().PlayerDeath();
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPlayerDead(bool playerDead)
    {
        PlayerDead = playerDead;
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
