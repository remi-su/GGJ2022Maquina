using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;
using Enumerator.GGJ;

public class PistolController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public int sizeByMagazine = 30;

    int actualMagazine;
    
    public void Shoot(Transform fireSpot)
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot Logic
            if (actualMagazine > 0)
            {
                Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
                actualMagazine--;
            }
        }
        
    }

    public void Reload()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<InventaryController>())
        {
            actualMagazine += player.GetComponent<InventaryController>().takeMunition(TypeBullets.Pistol,(sizeByMagazine - actualMagazine));
        }
    }
}
