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
        if (timer >= 3f)
        {
            int prev = randomNum;
            randomNum = Random.Range(0, 2);
            while (randomNum == prev)
            {
                randomNum = Random.Range(0, 2);
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
                MachineGun.SetActive(false);
                RailGun.SetActive(true);
                FireBall.SetActive(false);
                FindObjectOfType<FireRailGun>().Set_mayFire(true);
                break;

            case 2:
                MachineGun.SetActive(false);
                RailGun.SetActive(false);
                FireBall.SetActive(true);
                break;

            default:
                MachineGun.SetActive(true);
                RailGun.SetActive(false);
                FireBall.SetActive(false);
                break;

        }
    }

    IEnumerator EnableMachineGun()
    {
        yield return new WaitForSeconds(0.1f);
        MachineGun.SetActive(true);
        RailGun.SetActive(false);
        FireBall.SetActive(false);
        FindObjectOfType<FireMachineGun>().Set_mayFire(true);
    }
}
