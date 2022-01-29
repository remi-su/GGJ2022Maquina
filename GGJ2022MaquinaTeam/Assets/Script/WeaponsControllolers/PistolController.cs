
using UnityEngine;
using Assets.Script.Interfaces;

public class PistolController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public Transform fireSpot; 
    public float lifeWeapon;
    public float initialLifeWeapon;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float damagePerBullet;
    public bool statusLocked = false;
    private bool canShoot = true;

    private void Awake()
    {
        lifeWeapon = initialLifeWeapon;
        timeBtwAttack = startTimeBtwAttack;
    }

    public void Shoot()
    {

        if (timeBtwAttack >= 0 && !canShoot)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        else
        {
            canShoot = true;
            timeBtwAttack = startTimeBtwAttack;
        }

        if (Input.GetButton("Fire1") && canShoot)
        {
            //Shoot Logic
            if (lifeWeapon > 0)
            {
                Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
                lifeWeapon -= damagePerBullet;

                if (lifeWeapon <= 0)
                {
                    statusLocked = false;
                    transform.parent.gameObject.GetComponent<WeaponDefaultController>().SetKniveDefault();
                }

                canShoot = false;
            }
        }

    }

    public void CureWeapon(float amontHeal)
    {
        if (!statusLocked)
        {
            lifeWeapon += amontHeal;
        }
    }

    public void TakeNewInstance()
    {
        statusLocked = true;
        lifeWeapon = initialLifeWeapon;
    }

    public void TakeDamage(float damage)
    {
        lifeWeapon -= damage;
        Debug.Log("Taking Damage Pistol");
        if (lifeWeapon <= 0)
        {
            statusLocked = false;
            transform.parent.gameObject.GetComponent<WeaponDefaultController>().SetKniveDefault();
        }
    }

    public float getLife()
    {
        return lifeWeapon;
    }

    public bool getStatusLocked()
    {
        return statusLocked;
    }
}
