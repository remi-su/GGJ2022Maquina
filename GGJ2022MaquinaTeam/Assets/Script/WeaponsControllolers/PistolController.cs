
using UnityEngine;
using Assets.Script.Interfaces;

public class PistolController : MonoBehaviour, IWeaponController
{
    public GameObject bulletPrefab;
    public Transform fireSpot; 
    public float lifeWeapon;
    public float initialLifeWeapon;
    public float damagePerBullet;
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
                Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
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
        Debug.Log("Taking Damage Pistol");
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
