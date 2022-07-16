using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapons : MonoBehaviour
{

    [SerializeField] private GameObject MachineGun;
    [SerializeField] private GameObject RailGun;
    [SerializeField] private GameObject FireBall;

    private int randomNum = 0;
    private float timer = 0f;
    private bool maySwap = true;

    // Start is called before the first frame update
    void Start()
    {
        MachineGun.SetActive(false);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetWeapon();
    }

    private void SetWeapon()
    {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            int prev = randomNum;
            randomNum = Random.Range(0, 3);
            while (randomNum == prev)
            {
                randomNum = Random.Range(0, 3);
            }
            maySwap = true;
            timer = 0f;
        }

        switch (randomNum)
        {
            case 0:
                if (maySwap)
                {
                    StartCoroutine(EnableMachineGun());
                    maySwap = false;
                }
                break;

            case 1:
                if (maySwap)
                {
                    StartCoroutine(EnableRailGun());
                    maySwap = false;
                }
                break;

            case 2:
                if (maySwap)
                {
                    StartCoroutine(EnableFireBall());
                    maySwap = false;
                }
                break;

            default:
                if (maySwap)
                {
                    StartCoroutine(EnableMachineGun());
                    maySwap = false;
                }
                break;

        }
    }

    public int GetRandomInt()
    {
        return randomNum;
    }
    IEnumerator EnableMachineGun()
    {
        yield return new WaitForSeconds(0.1f);
        MachineGun.SetActive(true);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
        FindObjectOfType<FireMachineGun>().Set_mayFire(true);
    }

    IEnumerator EnableRailGun()
    {
        yield return new WaitForSeconds(0.1f);
        MachineGun.SetActive(false);
        RailGun.SetActive(true);
        FireBall.SetActive(false);
        FindObjectOfType<FireRailGun>().Set_mayFire(true);
    }

    IEnumerator EnableFireBall()
    {
        yield return new WaitForSeconds(0.1f);
        MachineGun.SetActive(false);
        RailGun.SetActive(false);
        FireBall.SetActive(true);
        FindObjectOfType<Shoot_FireBall>().Set_mayFire(true);
    }
}
