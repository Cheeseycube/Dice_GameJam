using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapons : MonoBehaviour
{

    [SerializeField] private GameObject MachineGun;
    [SerializeField] private GameObject RailGun;
    [SerializeField] private GameObject FireBall;

    private int randomNum = 0;
    private int prevWeapon = 0;
    private float timer = 0f;
    private bool maySwap = true;
    private bool swappingWeapons = false;

    private float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        MachineGun.SetActive(true);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (maySwap)
        {
            print("swapping");
            maySwap = false;
            StartCoroutine(WeaponTimer());
        }
        //SetWeapon();
    }

    // use the coroutines to start off the animations
    IEnumerator EnableMachineGun()
    {
        yield return new WaitForSeconds(waitTime);
        MachineGun.SetActive(true);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
        FindObjectOfType<FireMachineGun>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().SetMachineGun();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }

    IEnumerator EnableRailGun()
    {
        yield return new WaitForSeconds(waitTime);
        MachineGun.SetActive(false);
        RailGun.SetActive(true);
        FireBall.SetActive(false);
        FindObjectOfType<FireRailGun>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().SetRailGun();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }

    IEnumerator EnableFireBall()
    {
        yield return new WaitForSeconds(waitTime);
        MachineGun.SetActive(false);
        RailGun.SetActive(false);
        FireBall.SetActive(true);
        FindObjectOfType<Shoot_FireBall>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().SetFireBall();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }

    // Animations will be put in later?

    private void SwapWeapons()
    {
        FindObjectOfType<WeaponsUI>().EnableAnimations();
        switch (GetRandomNum())
        {
            case 0:
                FindObjectOfType<WeaponsUI>().SwappingMachineGun();
                StartCoroutine(EnableMachineGun()); 
                break;

            case 1:
                FindObjectOfType<WeaponsUI>().SwappingFireBall();
                StartCoroutine(EnableRailGun());
                break;

            case 2:
                FindObjectOfType<WeaponsUI>().SwappingFireBall();
                StartCoroutine(EnableFireBall());
                break;

            default:
                FindObjectOfType<WeaponsUI>().SwappingMachineGun();
                StartCoroutine(EnableMachineGun());
                break;

        }
    }


    IEnumerator WeaponTimer()
    {
        yield return new WaitForSeconds(waitTime);
        SwapWeapons();
    }

    private int GetRandomNum()
    {
        prevWeapon = randomNum;
        randomNum = Random.Range(0, 3);
        while (randomNum == prevWeapon)
        {
            randomNum = Random.Range(0, 3);
        }

        return randomNum;
    }


}
