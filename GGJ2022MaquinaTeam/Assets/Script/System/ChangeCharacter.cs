using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChangeCharacter : MonoBehaviour
{

    public GameObject player_01;
    public GameObject player_02;
    public GameObject enviroment_01;
    public GameObject enviroment_02;
    public float timeToChange;
    public string tagNextPlayer;

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
        tagNextPlayer = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionPlayer;
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        bool isTimeStop = false;
        if (gameManager.GetComponent<GameManager>())
        {
            isTimeStop = gameManager.GetComponent<GameManager>().GetStateTimeGame();
        }

        if (isTimeStop)
        {
            return;
        }

        if (Input.GetButtonDown("ChangeWorld") && canChange)
        {
            if (isPlayerOneActive)
            {
                positionPlayer = player_01.transform.position;
                tagNextPlayer = "Player2";
                player_01.SetActive(false);
                enviroment_01.SetActive(false);
                enviroment_02.SetActive(true);
                player_02.SetActive(true);
                player_02.transform.position = positionPlayer;
                isPlayerOneActive = false;
            } else
            {
                positionPlayer = player_02.transform.position;
                tagNextPlayer = "Player";
                player_02.SetActive(false);
                enviroment_02.SetActive(false);
                enviroment_01.SetActive(true);
                player_01.SetActive(true);
                player_01.transform.position = positionPlayer;
                isPlayerOneActive = true;
            }
            AstarPathEditor.MenuScan();
            FindObjectOfType<AudioManager>().ChangeWorld(isPlayerOneActive, false);
            FindObjectOfType<RipplePostProcessor>().RippleEffect(positionPlayer);
            //ChangeTargetEnemys(tagNextPlayer);
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

    void ChangeTargetEnemys(string tagNextPlayer)
    {
        
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag(tagNextPlayer);

        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i].GetComponent<AIDestinationSetter>())
            {
                enemys[i].GetComponent<AIDestinationSetter>().target = player.transform;
            }
        }
    }
}
