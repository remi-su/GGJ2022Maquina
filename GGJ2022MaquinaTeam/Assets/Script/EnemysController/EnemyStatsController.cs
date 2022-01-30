using UnityEngine;

public class EnemyStatsController : MonoBehaviour
{
    public float HP;
    public GameObject gameObjectToDestroy;
    public GameObject bloodEffect;
    public GameObject manchaSangre;

    
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
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if (manchaSangre != null)
        {
            Instantiate(manchaSangre, transform.position, gameObject.transform.rotation);
        }
        
        FindObjectOfType<ShakeCamara>().CamShake();
        Destroy(gameObjectToDestroy.gameObject);
    }

    public void makeDamage(float damage)
    {
        HP -= damage;
    }

    public void MakeAEnemy()
    {
        if (gameObject.layer == 13)
        {
            gameObject.layer = 8;
        }
    }

    
}
