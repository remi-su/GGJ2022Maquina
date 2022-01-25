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


    public void Shoot()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].GetComponent<EnemyStatsController>())
                    {
                        enemiesToDamage[i].GetComponent<EnemyStatsController>().makeDamage(damage);
                    }
                }
            }
        } else
        {
            timeBtwAttack -= Time.deltaTime;
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

}
