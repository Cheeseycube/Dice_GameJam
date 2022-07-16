using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    [SerializeField] private GameObject FirePoint;

    private float moveSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
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
        transform.Translate(Vector2.right * moveSpeed);
    }

    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // DO THIS LAST
        Destroy(gameObject);

    }
}
