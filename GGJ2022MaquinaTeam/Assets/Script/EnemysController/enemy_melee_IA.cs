using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_melee_IA : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public string nombre_jugador;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rang_ataque;
    public GameObject rango;
    public GameObject hit;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find(nombre_jugador);
    }

    // Update is called once per frame
    void Update()
    {
        comportamientos();
    }

    public void comportamientos() {

        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {

            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:

                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else if (Mathf.Abs(transform.position.x - target.transform.position.x) > rang_ataque && !atacando)
        {
            if (transform.position.x < target.transform.position.x)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0,0,0);
                ani.SetBool("attack", false);

            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                ani.SetBool("attack", false);
            }

        }
        else if (!atacando)
        {
            if (transform.position.x < target.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0,0,0);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
        }
    }

    public void final_ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void colliderweapontrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void colliderweaponfalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }
}
