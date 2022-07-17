using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// author: Spencer Pham
// Changes an object's sprite between two given sprites.

public class ButtonImage : MonoBehaviour
{
    private bool isA = true; // Tracks the current sprite.
    [SerializeField] Sprite SpriteStart;
    [SerializeField] Sprite SpriteSwap;
    [SerializeField] GameObject Object; // Object's sprite to adjust. Object must have an Image component.

    public void imageSwap()
    {
        if (isA)
        {
            Object.GetComponent<Image>().sprite = SpriteSwap;
            isA = false;
        } else
        {
            Object.GetComponent<Image>().sprite = SpriteStart;
            isA = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
