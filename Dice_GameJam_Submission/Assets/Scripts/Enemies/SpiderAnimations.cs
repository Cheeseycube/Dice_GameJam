using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimations : MonoBehaviour
{
    private GameObject player;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (GetDistanceFromPlayer() <= 5f)
        {
            myAnim.SetBool("attacking", true);
        }
        else
        {
            myAnim.SetBool("attacking", false);
        }
    }
    private float GetDistanceFromPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
