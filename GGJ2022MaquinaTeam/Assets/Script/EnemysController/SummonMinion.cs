using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interfaces;

public class SummonMinion : MonoBehaviour, IWeaponController
{
    public GameObject minionPrefab;
    private Transform minionInstance;
    public Transform fireSpot;
    public float initialTimeFire;
    private float timeFire;
    public float manaCost;
    public bool statusLocked = false;
    private bool canSummon = true;

    private void Awake()
    {
        timeFire = initialTimeFire;
        minionInstance = Instantiate(minionPrefab, fireSpot.position, fireSpot.rotation).transform;
        minionInstance.gameObject.SetActive(false);
    }

    public void Shoot()
    {

        if (timeFire >= 0 && !canSummon)
        {
            timeFire -= Time.deltaTime;
        }
        else
        {
            canSummon = true;
            timeFire = initialTimeFire;
        }

        if (Input.GetButtonDown("Fire1") && canSummon)
        {
            
            if (consumeMana())
            {
                if (!minionInstance.gameObject.activeInHierarchy)
                {
                    minionInstance.gameObject.SetActive(true);
                }
                minionInstance.position = fireSpot.position;

                canSummon = false;
            }
        }

    }

    private bool consumeMana()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player2");

        return player.GetComponent<CharacterController2D>().ConsumirMana(manaCost);
    }

    public void CureWeapon(float amontHeal)
    {

    }

    public void TakeNewInstance()
    {

    }

    public void TakeDamage(float damage)
    {

    }

    public bool getStatusLocked()
    {
        return statusLocked;
    }
}

