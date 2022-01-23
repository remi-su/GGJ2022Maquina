using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;

public class WeaponDefaultController : MonoBehaviour
{

    public GameObject arsenal;

    // Update is called once per frame
    void Update()
    {
        if (arsenal.transform.childCount != 0)
        {

            if (arsenal.transform.GetChild(0).GetComponent<IWeaponController>() != null)
            {
                arsenal.transform.GetChild(0).GetComponent<IWeaponController>().Shoot();
            }
            

            if (Input.GetButtonDown("Reload"))
            {
                if (arsenal.transform.GetChild(0).GetComponent<IWeaponController>() != null)
                {
                    arsenal.transform.GetChild(0).GetComponent<IWeaponController>().Reload();
                }
            }
        }
    }
}
