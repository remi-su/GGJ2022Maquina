using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    public GameObject player_01;
    public GameObject player_02;
    public GameObject enviroment_01;
    public GameObject enviroment_02;
    public float timeToChange;

    float timeToChangeTotal;
    bool canChange;
    bool isPlayerOneActive;

    // Start is called before the first frame update
    void Start()
    {
        timeToChangeTotal = timeToChange;
        canChange = true;
        isPlayerOneActive = true;
        player_02.SetActive(false);
        enviroment_02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionPlayer;

        if (Input.GetButtonDown("ChangeWorld") && canChange)
        {
            if (isPlayerOneActive)
            {
                positionPlayer = player_01.transform.position;
                player_01.SetActive(false);
                enviroment_01.SetActive(false);
                enviroment_02.SetActive(true);
                player_02.SetActive(true);
                player_02.transform.position = positionPlayer;
                isPlayerOneActive = false;
            } else
            {
                positionPlayer = player_02.transform.position;
                player_02.SetActive(false);
                enviroment_02.SetActive(false);
                enviroment_01.SetActive(true);
                player_01.SetActive(true);
                player_01.transform.position = positionPlayer;
                isPlayerOneActive = true;
            }

            canChange = false;
        }

        if (!canChange)
        {
            if (timeToChangeTotal >= 0)
            {
                timeToChangeTotal -= Time.deltaTime;
            } else
            {
                timeToChangeTotal = timeToChange;
                canChange = true;
            }
        }
    }
}
