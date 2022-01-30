using UnityEngine;
using Assets.Script.Interfaces;

public class ShotgunController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public float lifeWeapon;
    public float initialLifeWeapon;
    public float damagePerBullet;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform fireSpot;
    public Transform spot_01;
    public Transform spot_02;
    public Transform spot_03;
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

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            //Shoot Logic
            if (lifeWeapon > 0)
            {
                GameObject bullet_01 = Instantiate(bulletPrefab, spot_01.position, spot_01.rotation);
                GameObject bullet_02 = Instantiate(bulletPrefab, spot_02.position, spot_02.rotation);
                Instantiate(bulletPrefab, spot_03.position, spot_03.rotation);
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
        if (statusLocked)
        {
            if (initialLifeWeapon >= (lifeWeapon + amontHeal))
            {
                lifeWeapon += amontHeal;
            }
            else
            {
                lifeWeapon = initialLifeWeapon;
            }

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
        Debug.Log("Taking Damage Escopeta");
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
