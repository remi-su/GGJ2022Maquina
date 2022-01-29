
using UnityEngine;
using Assets.Script.Interfaces;

public class EyeAttackController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public Transform fireSpot;
    public float initialTimeFire;
    private float timeFire;
    public float manaCost;
    public bool statusLocked = false;

    private void Awake()
    {
        timeFire = initialTimeFire;
    }

    public void Shoot()
    {

        if (Input.GetButton("Fire1"))
        {
            //Shoot Logic
            if (timeFire >= 0)
            {
                timeFire -= Time.deltaTime;
            } else
            {
                timeFire = initialTimeFire;

                if (consumeMana())
                {
                    GameObject bulletInstance = Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
                    bulletInstance.GetComponent<BulletController>().whomshoot = gameObject;
                }
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

    public float getLife()
    {
        return 0;
    }

    public bool getStatusLocked()
    {
        return statusLocked;
    }
}

