using UnityEngine;
using System.Linq;
using Assets.Script.Interfaces;

public class BulletController : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float damage;
    public string[] objectsToEvade;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!objectsToEvade.Contains(collision.gameObject.tag))
        {
            if (collision.gameObject.GetComponent<EnemyStatsController>())
            {
                collision.gameObject.GetComponent<EnemyStatsController>().makeDamage(damage);
            }

            if (collision.gameObject.GetComponent<CharacterController2D>())
            {
                collision.gameObject.GetComponent<CharacterController2D>().takedamage(damage);
            }

            if (collision.gameObject.transform.parent != null)
            {
                if (collision.gameObject.transform.parent.gameObject.GetComponent<IWeaponController>() != null)
                {
                    collision.gameObject.transform.parent.gameObject.GetComponent<IWeaponController>().TakeDamage(damage);
                }
            }
            
            Destroy(gameObject);
        }
        
    }
}
