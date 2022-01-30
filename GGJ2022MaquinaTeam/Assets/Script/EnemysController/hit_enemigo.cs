using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<CharacterController2D>())
            {
                collision.gameObject.GetComponent<CharacterController2D>().takedamage(20);
            }
        }
    }
}
