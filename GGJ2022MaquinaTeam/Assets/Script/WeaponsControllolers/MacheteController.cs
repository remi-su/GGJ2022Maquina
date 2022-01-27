using UnityEngine;
using Assets.Script.Interfaces;

public class MacheteController : MonoBehaviour, IWeaponController
{
    public float damage = 5.5f;
    public bool statusLocked = false;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    private bool canShoot = true;


    public void Shoot()
    {
        if (timeBtwAttack >= 0 && !canShoot)
        {
            timeBtwAttack -= Time.deltaTime;
        } else
        {
            canShoot = true;
            timeBtwAttack = startTimeBtwAttack;
        }

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].GetComponent<EnemyStatsController>())
                {
                    enemiesToDamage[i].GetComponent<EnemyStatsController>().makeDamage(damage);
                    enemiesToDamage[i].GetComponent<EnemyStatsController>().MakeAEnemy();
                }
            }
            canShoot = false;
        }
    }

    public void CureWeapon(float amontHeal)
    {

    }

    public void TakeNewInstance()
    {

    }

    public bool getStatusLocked()
    {
        return statusLocked;
    }

    public void TakeDamage(float damage)
    {

    }

}
