using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezas : MonoBehaviour
{
    public int vida_cabeza;
    public GameObject cabeza;
    public GameObject tentaculo_a_destruir;
    public GameObject EffectToDie;
    public GameObject EffectToAttack;
    public float initialTimeAttack;
    public float timeAttack;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damageByDistorsion;

    private void Update()
    {
        if (vida_cabeza <= 0)
        {
            Instantiate(EffectToDie, transform.position, Quaternion.identity);
            FindObjectOfType<ShakeCamara>().CamShake();
            destroy();

        }

        if (timeAttack >= 0)
        {
            timeAttack -= Time.deltaTime;
        } else
        {
            timeAttack = initialTimeAttack;
            TurbulenciaAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            takedamage(10);
        }
    }

    public void takedamage(int damage)
    {
        vida_cabeza = vida_cabeza - damage;
    }

    public void destroy()
    {
        Destroy(gameObject);
        Destroy(tentaculo_a_destruir); ;
    }

    void TurbulenciaAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsEnemies);
        Instantiate(EffectToAttack,transform.position, Quaternion.identity);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if (enemiesToDamage[i].GetComponent<EnemyStatsController>())
            {
                enemiesToDamage[i].GetComponent<EnemyStatsController>().makeDamage(damageByDistorsion);
            }

            if (enemiesToDamage[i].GetComponent<CharacterController2D>())
            {
                enemiesToDamage[i].GetComponent<CharacterController2D>().takedamage(damageByDistorsion);
            }
        }

    }
}
