using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author : Spencer Pham
// This script is used for the main menu to make the player move (shake or bob) in place.



public class player_shake : MonoBehaviour
{
    [SerializeField] int frameMax;
    [SerializeField] float distance;
    int frameLoop = 0;
    bool bounce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frameLoop == frameMax)
        {
            bounce = false;
        } else if (frameLoop == -1)
        {
            bounce = true;
        }
        if (bounce)
        {
            transform.position = transform.position + new Vector3(0, distance, 0);
            frameLoop++;
        } else
        {
            transform.position = transform.position - new Vector3(0, distance, 0);
            frameLoop--;
        }
    }
}
