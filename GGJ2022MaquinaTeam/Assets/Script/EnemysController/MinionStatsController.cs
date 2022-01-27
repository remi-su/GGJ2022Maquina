
using UnityEngine;

public class MinionStatsController : MonoBehaviour
{
    public float HP;
    public float MAXHP;
    public GameObject gameObjectToDestroy;

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
