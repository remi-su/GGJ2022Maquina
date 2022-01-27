
using UnityEngine;
using Pathfinding;

public class TentacleEyeController : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 direction;
    private GameObject target;
    public GameObject objectWithDestinationSetter;
    public float distanceDetect;
    public LayerMask whatIsEnemies;
    public float distanceToShoot;
    public GameObject pointToShot;
    public GameObject bullet;
    public float startTimebtwAttack;
    private float timebtwAttack;


    private void Start()
    {
        timebtwAttack = startTimebtwAttack;
    }

    // Update is called once per frame
    void Update()
    {
        DeterminarTarget();
        SeePlayer();
        FollowTarget();
        ShootingEnemys();
    }

    private void ShootingEnemys()
    {
        float distance = 0;
        if (target != null && target.tag != "Player2")
        {
            distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance <= distanceToShoot)
            {
                if (timebtwAttack >= 0)
                {
                    timebtwAttack -= Time.deltaTime;
                } else
                {
                    timebtwAttack = startTimebtwAttack;
                    Instantiate(bullet, pointToShot.transform.position, pointToShot.transform.rotation);
                }
            }
            
        }
    }

    public void InvocarCriatura()
    {
        target = GameObject.FindGameObjectWithTag("Player2");
    }

    void SeePlayer()
    {
        if (target != null)
        {
            direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        
    }

    void DeterminarTarget()
    {
        GameObject changeCharacter = GameObject.FindGameObjectWithTag("GameManager");

        if (changeCharacter.GetComponent<ChangeCharacter>().tagNextPlayer == "Player2")
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, distanceDetect, whatIsEnemies);
            if (enemiesToDamage.Length != 0 && (target == null || target.tag == "Player2" || target.tag == "Player"))
            {
                target = enemiesToDamage[0].gameObject;
            }
            else if (enemiesToDamage.Length == 0)
            {
                target = GameObject.FindGameObjectWithTag("Player2");
            }
        } else
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FollowTarget()
    {
        if (objectWithDestinationSetter.GetComponent<AIDestinationSetter>())
        {
            if (target != null)
            {
                objectWithDestinationSetter.GetComponent<AIDestinationSetter>().target = target.transform;
            }
        }
    }
}
