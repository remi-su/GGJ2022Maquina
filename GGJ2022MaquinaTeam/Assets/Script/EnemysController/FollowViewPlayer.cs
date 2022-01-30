using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowViewPlayer : MonoBehaviour
{

    private Vector2 direction;
    private GameObject target;
    public float rotationSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeterminarTarget();
        SeePlayer();
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
        string tag = changeCharacter.GetComponent<ChangeCharacter>().tagNextPlayer;

        if (GameObject.FindGameObjectWithTag(tag) != null)
        {
            target = GameObject.FindGameObjectWithTag(tag);
        }
        else
        {
            target = null;
        }
    }
}
