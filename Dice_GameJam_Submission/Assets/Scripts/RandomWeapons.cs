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

    private int CurrentWeapon = 0;

    private float waitTime = 3f;
    private float diceRollTime = 3f;
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
            maySwap = false;
            StartCoroutine(WeaponTimer());
        }
        //SetWeapon();
    }

    // use the coroutines to start off the animations
    IEnumerator EnableMachineGun()
    {
        yield return new WaitForSeconds(diceRollTime);
        MachineGun.SetActive(true);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
        FindObjectOfType<FireMachineGun>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().NoDiceRolling();
        FindObjectOfType<WeaponsUI>().SetMachineGun();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }

    IEnumerator EnableRailGun()
    {
        yield return new WaitForSeconds(diceRollTime);
        MachineGun.SetActive(false);
        RailGun.SetActive(true);
        FireBall.SetActive(false);
        FindObjectOfType<FireRailGun>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().NoDiceRolling();
        FindObjectOfType<WeaponsUI>().SetRailGun();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }

    IEnumerator SwappingRailGunAnim()
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<WeaponsUI>().DiceRolling();
        StartCoroutine(EnableRailGun());
    }
    IEnumerator SwappingMachineGunAnim()
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<WeaponsUI>().DiceRolling();
        StartCoroutine(EnableMachineGun());
    }
    IEnumerator SwappingFireBallAnim()
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<WeaponsUI>().DiceRolling();
        StartCoroutine(EnableFireBall());
    }

    IEnumerator EnableFireBall()
    {
        yield return new WaitForSeconds(diceRollTime);
        MachineGun.SetActive(false);
        RailGun.SetActive(false);
        FireBall.SetActive(true);
        FindObjectOfType<Shoot_FireBall>().Set_mayFire(true);
        FindObjectOfType<WeaponsUI>().NoDiceRolling();
        FindObjectOfType<WeaponsUI>().SetFireBall();
        FindObjectOfType<WeaponsUI>().DisableAnimations();
        maySwap = true;
    }


    private void SwapWeapons()
    {
        FindObjectOfType<WeaponsUI>().EnableAnimations();
        switch (CurrentWeapon)
        {
            case 0:
                FindObjectOfType<WeaponsUI>().SwappingMachineGun();
                break;

            case 1:
                FindObjectOfType<WeaponsUI>().SwappingRailGun();
                break;

            case 2:
                FindObjectOfType<WeaponsUI>().SwappingFireBall();
                break;

            default:
                FindObjectOfType<WeaponsUI>().SwappingMachineGun();
                break;

        }
        switch (GetRandomNum())
        {
            case 0:
                CurrentWeapon = 0;
                StartCoroutine(SwappingMachineGunAnim());
                break;

            case 1:
                CurrentWeapon = 1;
                StartCoroutine(SwappingRailGunAnim());
                break;

            case 2:
                CurrentWeapon = 2;
                StartCoroutine(SwappingFireBallAnim());
                break;

            default:
                CurrentWeapon = 0;
                StartCoroutine(SwappingMachineGunAnim());
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
        //prevWeapon = randomNum;

        return randomNum;
    }


}
