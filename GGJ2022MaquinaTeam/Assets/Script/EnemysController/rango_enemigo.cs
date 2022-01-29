using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rango_enemigo : MonoBehaviour
{
    public Animator ani;
    public enemy_melee_IA enemigo;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
