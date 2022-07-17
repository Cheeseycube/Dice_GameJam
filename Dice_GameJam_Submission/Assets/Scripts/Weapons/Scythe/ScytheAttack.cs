using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    private bool mayAttack = true;
    [SerializeField] private GameObject ScytheCol;
    Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       Attack();
    }

    public void Set_mayFire(bool FireBool)
    {
        mayAttack = FireBool;
    }
    private void Attack()
    {
        if (Input.GetMouseButton(0) && mayAttack)
        {
            mayAttack = false;
            // enable collider
            //ScytheCol.SetActive(true);
            myanim.SetBool("Scythe Attacking", true);
            StartCoroutine(TransformScaleTimer());
            StartCoroutine(AttackTimer());
            StartCoroutine(AttackRateTimer());
            StartCoroutine(ColliderTimerStart());
        }
    }

    IEnumerator AttackRateTimer()
    {
        yield return new WaitForSeconds(2f);
        mayAttack = true;
    }

    IEnumerator ColliderTimer()
    {
        yield return new WaitForSeconds(0.2f);
        ScytheCol.SetActive(false);
    }

    IEnumerator ColliderTimerStart()
    {
        yield return new WaitForSeconds(0.7f);
        ScytheCol.SetActive(true);
        StartCoroutine(ColliderTimer());
    }
    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1f);
        myanim.SetBool("Scythe Attacking", false);
        gameObject.transform.localPosition = new Vector2(4.22f, -1.67f);
        gameObject.transform.localScale = new Vector2(2, 2);
    }

    IEnumerator TransformScaleTimer()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.localPosition = new Vector2(0, 0);
        gameObject.transform.localScale = new Vector2(5, 5);
    }
}
