using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyEnemyIA : MonoBehaviour
{
    public GameObject BodyToMove;
    public float rotationSpeed;
    public int layerAlly = 13;
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
    float posX, posY;
    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 0.5f, angle = 0f;


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
        MakeCircleMovement();
    }

    private void ShootingEnemys()
    {
        float distance = 0;
        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);

            if (distance <= distanceToShoot)
            {
                if (timebtwAttack >= 0)
                {
                    timebtwAttack -= Time.deltaTime;
                }
                else
                {
                    timebtwAttack = startTimebtwAttack;
                    Instantiate(bullet, pointToShot.transform.position, pointToShot.transform.rotation);
                }
            }

        }
    }

    private void MakeCircleMovement()
    {

        if (target != null)
        {
            if (Mathf.Abs(Vector2.Distance(BodyToMove.transform.position, target.transform.position)) <= 4)
            {
                posX = target.transform.position.x + Mathf.Cos(angle) * rotationRadius;
                posY = target.transform.position.y + Mathf.Sin(angle) * rotationRadius;
                BodyToMove.transform.position = new Vector2(posX, posY);
                angle = angle + Time.deltaTime * angularSpeed;

                if (angle >= 2)
                    angularSpeed *= -1;

                if (angle <= 0.7f)
                {
                    angularSpeed *= -1;
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

            if (gameObject.layer == layerAlly)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, distanceDetect, whatIsEnemies);
                if (enemiesToDamage.Length != 0 && (target == null || target.tag == "Player"))
                {
                    target = enemiesToDamage[0].gameObject;
                }

                if (enemiesToDamage.Length == 0)
                {
                    target = null;
                }
            } else
            {
                if (target == null)
                {
                    if (GameObject.FindGameObjectWithTag("Player2") != null)
                    {
                        target = GameObject.FindGameObjectWithTag("Player2");
                    } else
                    {
                        target = null;
                    }
                    
                } else
                {
                    if (!target.activeInHierarchy)
                    {
                        if (GameObject.FindGameObjectWithTag("Player2") != null)
                        {
                            target = GameObject.FindGameObjectWithTag("Player2");
                        }
                        else
                        {
                            target = null;
                        }
                    }
                }
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            } else
            {
                target = null;
            }
            
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
    public void changeTargetByAttacking(GameObject newTarget)
    {

        if (target == null)
        {
            target = newTarget;
        } else
        {
            if (target.layer == 3 || target.layer == 7)
            {
                target = newTarget;
            }
        }
        
    }
}
