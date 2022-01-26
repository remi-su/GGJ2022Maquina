using UnityEngine;
using Assets.Script.Interfaces;

public class ShotgunController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public float lifeWeapon;
    public float initialLifeWeapon;
    public float damagePerBullet;
    public Transform fireSpot;
    public Transform spot_01;
    public Transform spot_02;
    public Transform spot_03;
    public bool statusLocked = false;

    private void Awake()
    {
        lifeWeapon = initialLifeWeapon;
    }

    public void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
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
        Debug.Log("Taking Damage Escopeta");
        if (lifeWeapon <= 0)
        {
            statusLocked = false;
            transform.parent.gameObject.GetComponent<WeaponDefaultController>().SetKniveDefault();
        }
    }

    public bool getStatusLocked()
    {
        return statusLocked;
    }
}
