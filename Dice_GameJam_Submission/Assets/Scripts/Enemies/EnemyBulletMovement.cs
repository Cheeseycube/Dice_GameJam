using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    private float bulletSpeed = .04f; // was .02f
    Vector3 fireDir;
    // Start is called before the first frame update
    void Start()
    {

        lifetimer();
        
    }

    public void Initialize(Vector2 direction)
    {
        fireDir = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(fireDir * bulletSpeed);

    }

    IEnumerator lifetimer()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

}
