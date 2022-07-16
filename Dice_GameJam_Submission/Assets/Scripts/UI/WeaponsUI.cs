using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUI : MonoBehaviour
{
    Image myImage;
    [SerializeField] private Sprite MachineGun;
    [SerializeField] private Sprite RailGun;
    [SerializeField] private Sprite FireBall;

    List<Sprite> spriteList = new List<Sprite>();
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        spriteList.Add(MachineGun);
        spriteList.Add(RailGun);
        spriteList.Add(FireBall);
    }

    // Update is called once per frame
    void Update()
    {
        SetImage();
    }

    private void SetImage()
    {
        myImage.sprite = spriteList[i];

        switch (FindObjectOfType<RandomWeapons>().GetRandomInt())
        {
            case 0:
                i = 0;
                break;
            case 1:
                i = 1;
                break;
            case 2:
                i = 2;
                break;
            default:
                break;
        }
    }
}
