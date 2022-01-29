
using UnityEngine;

public class MinionStatsController : MonoBehaviour
{
    public float HP;
    public float MAXHP;
    public GameObject gameObjectToDestroy;
    public GameObject bloodEffect;
    public GameObject manchaSangre;

    private void Start()
    {
        HP = MAXHP;
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
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Instantiate(manchaSangre, transform.position, gameObject.transform.rotation);
        FindObjectOfType<ShakeCamara>().CamShake();
        gameObjectToDestroy.SetActive(false);
    }

    public void makeDamage(float damage)
    {
        HP -= damage;
    }

    public void ResetStats()
    {
        HP = MAXHP;
    }
}
