using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossController : MonoBehaviour
{
    public GameObject effectoToSpawn;
    public GameObject enemyToSpawn;
    public Transform[] pointToSpawns;
    private bool isEnter;
    public float initialTimeSpawn;
    private float timeSpawn;
    public int effectsCounts;

    private void Start()
    {
        effectsCounts = pointToSpawns.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isEnter = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            if (effectsCounts > 0)
            {
                if (timeSpawn >= 0)
                {
                    timeSpawn -= Time.deltaTime;
                } else
                {
                    effectsCounts--;
                    Instantiate(effectoToSpawn, pointToSpawns[effectsCounts].position, Quaternion.identity);
                    FindObjectOfType<ShakeCamara>().CamShake();
                    timeSpawn = initialTimeSpawn;
                    
                }
            } else
            {

                enemyToSpawn.SetActive(true);

                Destroy(gameObject);
            }
        }
    }
}
