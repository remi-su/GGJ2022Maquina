using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_enemy : MonoBehaviour
{

    // A modificar con Pathfinding xd
    //se le asigna el objeto jugador (Personaje Principal)
    public Transform jugador;
    //El punto desde donde se dibuja el raycast
    public Transform inicio;
    //Velocidad de desplazamiento del enemigo
    private float speed = 1f;
    //bala
    public GameObject bala;
    //Lugar al que volver el enemigo, en caso de no ver al jugador
    private Vector3 puntoinicial;
    //Tipo de enemigo: Melee/Distance
    [Space]
    [Header("Tipo de enemigo")]
    [SerializeField] private bool isdistance_attack = false;
    [SerializeField] private bool ismelee_attack = false;
    RaycastHit2D hit, reconoce;
    [SerializeField]private float life = 100;
    [SerializeField] private GameObject detected;

    // Start is called before the first frame update
    void Start()
    {
        puntoinicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <=0)
        {
            destroy();
        }
        reconoce = Physics2D.Raycast(inicio.position, Vector2.left, 6f);
        Debug.DrawRay(inicio.position, Vector2.left * 6f, Color.red);
        if (reconoce)
        {
            if (reconoce.collider.CompareTag("Player"))
            {
                detected.SetActive(true);
                transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
            }
            else if (reconoce.collider.CompareTag("obstaculo"))
            {
                transform.position = Vector2.MoveTowards(transform.position, puntoinicial, speed * Time.deltaTime);
            }
            if (isdistance_attack)
            {
                hit = Physics2D.Raycast(inicio.position, Vector2.left, 3f);
                Debug.DrawRay(inicio.position, Vector2.left * 3f, Color.blue);
                if (hit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        speed = 0;
                        Debug.Log("Plomazo");
                        disparar();
                    }
                }
                else if (!hit)
                {
                    detected.SetActive(false);
                    speed = 1;
                    transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
                }
            }
            else if (ismelee_attack)
            {
                hit = Physics2D.Raycast(inicio.position, Vector2.left, .2f);
                Debug.DrawRay(inicio.position, Vector2.left * .2f, Color.blue);
                if (hit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        speed = 0;
                        Debug.Log("Navajazo");
                    }
                }
                else if (!hit)
                {
                    detected.SetActive(false);
                    speed = 1;
                    transform.position = Vector2.MoveTowards(transform.position, jugador.position, speed * Time.deltaTime);
                }
            }
        }
        else if (!reconoce)
        {
            detected.SetActive(false);
            Debug.Log("Entre");
            speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, puntoinicial, speed * Time.deltaTime);
        }

    }

    private void disparar()
    {
        Instantiate(bala, inicio.position, inicio.rotation );
    }

    public void takedamage(float damage)
    {
        life = life - damage;
    }
    public void destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            takedamage(20);
        }
    }

}
