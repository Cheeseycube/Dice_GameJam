using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator myanim;
    Quaternion currentRotation;
    Vector3 currentEulerAngles;
    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentRotation = transform.rotation;
        //currentEulerAngles = transform.eulerAngles;
        SetAnimations();
        FlipSprite();
        print(transform.eulerAngles.z);
    }
    // between 145 and -145 is facing left
    private void SetAnimations()
    {
        //print(transform.rotation.z);
        if ( ((transform.eulerAngles.z < 220) && (transform.eulerAngles.z > 150)) || (transform.eulerAngles.z < 22) || ((transform.eulerAngles.z < 360) && (transform.eulerAngles.z > 320)) )
        {
            myanim.SetBool("Facing Side", true);
            myanim.SetBool("Facing Front", false);
        }
        else
        {
            myanim.SetBool("Facing Side", false);
            myanim.SetBool("Facing Front", true);
        }
    }

    private void FlipSprite()
    {
        if ((transform.eulerAngles.z < 220) && (transform.eulerAngles.z > 150))
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, -1);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, 1);
        }
    }
}