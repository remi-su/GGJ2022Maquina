using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabezas : MonoBehaviour
{
    public int vida_cabeza;
    public GameObject cabeza;
    public GameObject tentaculo_a_destruir;

    private void Update()
    {
        if (vida_cabeza <= 0)
        {
            destroy();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            takedamage(10);
        }
    }

    public void takedamage(int damage)
    {
        vida_cabeza = vida_cabeza - damage;
    }

    public void destroy()
    {
        Destroy(gameObject);
        Destroy(tentaculo_a_destruir); ;
    }
}
