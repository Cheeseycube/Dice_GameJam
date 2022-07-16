using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUI : MonoBehaviour
{
    Image myImage;
    Animator myAnim;
    [SerializeField] private Sprite MachineGun;
    [SerializeField] private Sprite RailGun;
    [SerializeField] private Sprite FireBall;

    List<Sprite> spriteList = new List<Sprite>();
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myImage = GetComponent<Image>();
        spriteList.Add(MachineGun);
        spriteList.Add(RailGun);
        spriteList.Add(FireBall);
    }

    // Update is called once per frame
    void Update()
    {
        //SetImage();
    }

    /*private void SetImage()
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
    }*/

    public void SetMachineGun()
    {
        myImage.sprite = spriteList[0];
    }
    public void SetRailGun()
    {
        myImage.sprite = spriteList[1];
    }
    public void SetFireBall()
    {
        myImage.sprite = spriteList[2];
    }

    public void SwappingFireBall()
    {
        myAnim.SetBool("Machine Gun Changing", false);
        myAnim.SetBool("Fire Changing", true);
    }

    public void SwappingMachineGun()
    {
        myAnim.SetBool("Fire Changing", false);
        myAnim.SetBool("Machine Gun Changing", true);
    }

    public void DisableAnimations()
    {
        myAnim.enabled = false;
    }

    public void EnableAnimations()
    {
        myAnim.enabled = true;
    }
}
