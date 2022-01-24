using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;

public class WeaponDefaultController : MonoBehaviour
{

    public GameObject arsenal;
    public int weaponActivate;
    public int limitweapon = 3;

    private void Awake()
    {
        weaponActivate = 0;
        arsenal.transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<FirePointController>().firePoint = arsenal.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (arsenal.transform.childCount != 0)
        {

            if (arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>() != null)
            {
                arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>().Shoot();
            }
            

            if (Input.GetButtonDown("Reload"))
            {
                if (arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>() != null)
                {
                    arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>().Reload();
                }
            }
        }

        if (Input.GetButtonDown("NextWeapon"))
        {
            weaponActivate++;
            if (weaponActivate >= limitweapon)
            {
                weaponActivate = 0;
            }

            changeWeapon(determinarSiguienteArmaLibre(weaponActivate));
        }

        if (Input.GetButtonDown("LastWeapon"))
        {
            weaponActivate--;
            if (weaponActivate < 0)
            {
                weaponActivate = limitweapon - 1;
            }

            changeWeapon(determinarAnteriorArmaLibre(weaponActivate));
        }
    }

    private void changeWeapon(int idWeapon)
    {
        for (int i = 0; i < arsenal.transform.childCount; i++)
        {
            arsenal.transform.GetChild(i).gameObject.SetActive(false);
        }

        arsenal.transform.GetChild(idWeapon).gameObject.SetActive(true);
        GetComponent<FirePointController>().firePoint = arsenal.transform.GetChild(idWeapon).GetChild(0).gameObject;
    }

    private int determinarSiguienteArmaLibre(int weaponActivate)
    {
        if (arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>().getStatusLocked())
        {
            return weaponActivate;
        } else
        {
            weaponActivate++;
            this.weaponActivate++;
            if (weaponActivate >= limitweapon)
            {
                weaponActivate = 0;
                this.weaponActivate = 0;
            }
        }

        return determinarSiguienteArmaLibre(weaponActivate);
    }

    private int determinarAnteriorArmaLibre(int weaponActivate)
    {
        if (arsenal.transform.GetChild(weaponActivate).GetComponent<IWeaponController>().getStatusLocked())
        {
            return weaponActivate;
        }
        else
        {
            weaponActivate--;
            this.weaponActivate--;
            if (weaponActivate < 0)
            {
                weaponActivate = limitweapon - 1;
                this.weaponActivate = limitweapon - 1;
            }
        }

        return determinarAnteriorArmaLibre(weaponActivate);
    }
}
