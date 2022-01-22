using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;
using Enumerator.GGJ;

public class ShotgunController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public int sizeByMagazine = 6;
    public Transform fireSpot;
    public Transform spot_01;
    public Transform spot_02;
    public Transform spot_03;

    int actualMagazine;

    public void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot Logic
            if (actualMagazine > 0)
            {
                GameObject bullet_01 = Instantiate(bulletPrefab, spot_01.position, spot_01.rotation);
                GameObject bullet_02 = Instantiate(bulletPrefab, spot_02.position, spot_02.rotation);
                Instantiate(bulletPrefab, spot_03.position, spot_03.rotation);
                actualMagazine--;
            }
        }

    }

    public void Reload()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<InventaryController>())
        {
            actualMagazine += player.GetComponent<InventaryController>().takeMunition(TypeBullets.Shotgun, (sizeByMagazine - actualMagazine));
        }
    }
}
