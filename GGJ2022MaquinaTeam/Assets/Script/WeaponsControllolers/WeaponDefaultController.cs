using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;

public class WeaponDefaultController : MonoBehaviour
{

    public Transform fireSpot;
    public GameObject arsenal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arsenal.transform.childCount != 0)
        {

            if (arsenal.transform.GetChild(0).GetComponent<IWeaponController>() != null)
            {
                arsenal.transform.GetChild(0).GetComponent<IWeaponController>().Shoot(fireSpot);
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
