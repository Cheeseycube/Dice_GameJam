using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletMovement : MonoBehaviour
{
    public GameObject FirePoint;
    private float bulletSpeed = 0.8f;
    Vector3 fireDir;

    BoxCollider2D bulletCol;
    // Start is called before the first frame update
    void Start()
    {
        bulletCol = GetComponent<BoxCollider2D>();
        transform.Rotate(new Vector3(0f, 0f, FirePoint.transform.rotation.z));
        StartCoroutine(lifetimer());
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
        transform.Translate(Vector2.right * bulletSpeed);
    }

    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Foreground"))
        {
            Destroy(gameObject);
        }
    }
}
