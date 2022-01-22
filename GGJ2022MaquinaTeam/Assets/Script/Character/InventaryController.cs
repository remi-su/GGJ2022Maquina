using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerator.GGJ;

public class InventaryController : MonoBehaviour
{
    public int pistolMunition = 100;
    public int shotgunBullets = 50;

    public int takeMunition(TypeBullets type, int size)
    {
        switch (type)
        {
            case TypeBullets.Pistol:
                if (size < pistolMunition)
                {
                    pistolMunition -= size;
                    return size;
                } else if (pistolMunition < size)
                {
                    size = pistolMunition;
                    pistolMunition = 0;
                    return size;
                } else
                {
                    return 0;
                }
            case TypeBullets.Shotgun:
                if (size < shotgunBullets)
                {
                    shotgunBullets -= size;
                    return size;
                }
                else if (shotgunBullets < size)
                {
                    size = shotgunBullets;
                    shotgunBullets = 0;
                    return size;
                }
                else
                {
                    return 0;
                }
            default:
                return 0;
        }
    }
}
