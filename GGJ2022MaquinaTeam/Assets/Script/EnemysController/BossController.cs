using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform[] spots;
    public Transform body;
    public float speed;

    bool isRotatingMovement;
    bool isFollowPlayer;
    bool isGoingNewSpot;
    bool canChangeSpot;
    bool canAttack;
    bool isLaserAttacking;

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;

    float posX, posY, angle = 0f;
    Vector3 playerPosition;
    Vector3 spotPosition;

    float[] probabilityMovements;
    float[] probabilityAttacks;

    float timeChangingSpot = 3;
    float timeChangingSpotTotal;

    float timeAttacking = 3;
    float timeAttackingTotal;


    int actualSpot;


    //Parametros para el big laser attack
    public GameObject bigLaser;
    

    // Start is called before the first frame update
    void Start()
    {
        isRotatingMovement = true;
        isFollowPlayer = false;
        probabilityMovements = new float[] { 80f, 20f };
        canAttack = false;
        isLaserAttacking = false;
        canChangeSpot = true;
        timeAttackingTotal = timeAttacking;
        timeChangingSpotTotal = timeChangingSpot;

        if (bigLaser.GetComponent<BigLaserController>())
        {
            bigLaser.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (isRotatingMovement)
        {
            RotationMovement();
        }

        if (isFollowPlayer)
        {
            FollowPlayerMovement();
        }

        if (isGoingNewSpot)
        {
            MovementToNewSpot();
        }

        if (canChangeSpot)
        {
            if (timeChangingSpotTotal >= 0)
            {
                timeChangingSpotTotal -= Time.deltaTime;
            } else
            {
                timeChangingSpotTotal = timeChangingSpot;
                canChangeSpot = false;
                isRotatingMovement = false;
                getNewSpot();
                isGoingNewSpot = true;

                if (isLaserAttacking)
                {

                    if (bigLaser.GetComponent<BigLaserController>())
                    {
                        bigLaser.GetComponent<BigLaserController>().ResetPosition();
                        bigLaser.GetComponent<BigLaserController>().setMovingLaser(false);
                        bigLaser.SetActive(false);
                    }
                    isLaserAttacking = false;
                }
            }
        }

        if (canAttack)
        {
            if (timeAttackingTotal >= 0)
            {
                timeAttackingTotal -= Time.deltaTime;
            } else
            {
                timeAttackingTotal = timeAttacking;
                canAttack = false;
                isRotatingMovement = false;
                SelectAttackBySpot();
            }
        }

    }

    void RotationMovement()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        body.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }

    void getNewSpot()
    {
        int randomSpot = Random.Range(0, spots.Length);
        actualSpot = randomSpot + 1;
        Transform spot = spots[randomSpot];
        spotPosition = spot.position;
    }

    void MovementToNewSpot()
    {
        transform.position = Vector2.MoveTowards(transform.position, spotPosition, speed * Time.deltaTime);

        if (transform.position == spotPosition)
        {
            isGoingNewSpot = false;
            isRotatingMovement = true;
            canAttack = true;
        }
    }

    void FollowPlayerMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime * 2);

        if (transform.position == playerPosition)
        {
            getNewSpot();
            isGoingNewSpot = true;
            isFollowPlayer = false;
            canChangeSpot = true;
        }
    }

    void getPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
    }

    void SelectAttackBySpot()
    {
        switch (actualSpot)
        {
            case 1:
            case 2:
                Debug.Log("IsAttacking Player with attack direct");
                getPlayerPosition();
                isFollowPlayer = true;
                break;
            case 3:
            case 4:
                Debug.Log("Attack with Feathers");
                canChangeSpot = true;
                break;
            case 5:
                Debug.Log("Spawn Enemy");
                canChangeSpot = true;
                break;
            case 6:
                Debug.Log("Attack with a giant laser");
                GiantLaserAttack();
                break;
        }
    }

    void GiantLaserAttack()
    {
        if (bigLaser.GetComponent<BigLaserController>())
        {
            bigLaser.GetComponent<BigLaserController>().ResetPosition();
            bigLaser.GetComponent<BigLaserController>().setMovingLaser(true);
            bigLaser.SetActive(true);
            isLaserAttacking = true;
            canChangeSpot = true;
            timeAttackingTotal = 2.5f;
        }
    }
}
