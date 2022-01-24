using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsController : MonoBehaviour
{
    public float HP;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }

    public void makeDamage(float damage)
    {
        HP -= damage;
    }
}
