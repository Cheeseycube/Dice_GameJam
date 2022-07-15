using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletMovement : MonoBehaviour
{
    public GameObject FirePoint;
    private float bulletSpeed = 0.06f;
    Vector3 fireDir;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0f, 0f, FirePoint.transform.rotation.z));
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
}
