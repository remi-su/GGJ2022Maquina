using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float speed = 40; // Velocidad del personaje.
    public float distanceBetweenImages;
    private float lastImageXPos;
    private float timeNewDash = 0.5f; // Tiempo en el cual se puede realizar un nuevo dash
    private float dashTime = 0.2f; //Tiempo de duración del dash
    private float dashSpeed = 40; // Velocidad del Dash.
    CharacterController2D controller;

    bool isJumping = false; //Bandera que indica si el jugador esta saltando.
    bool isCroaching = false; //Bandera que indica si el jugador se esta agachando.
    bool isDashing = false; //  Bandera que indica si el jugador puede o esta dasheando.
    bool canDash = true; // Bandera qye determina si el jugador puede dashear.
    float dashTimeReal = 1;
    float newDashReal = 1;
    float horizontalMovement; //Valor que indica el movimiento horizontal del jugador. 
    float dashDirection;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
        dashTimeReal = dashTime;
        isDashing = false;
        newDashReal = timeNewDash;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (!isDashing)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * speed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCroaching = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            isCroaching = false;
        }

        dashAction();
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, isCroaching,isJumping);
        isJumping = false;
    }

    private void dashAction()
    {
        //Se determina si el jugador presiona el botón de Dash.
        if (Input.GetButtonDown("Dash") && canDash)
        {
            if (!isDashing)
            {
                dashDirection = Input.GetAxis("Horizontal");
                if (dashDirection != 0)
                {
                    isDashing = true;
                    canDash = false;
                    PlayerImageAfterPool.Instance.GetFromPool();
                    lastImageXPos = transform.position.x;
                }

            }
        }

        // Aquí se recarga la habilidad del dash por un tiempo determinado.
        if (!canDash)
        {
            if (newDashReal >= 0)
            {
                newDashReal -= Time.deltaTime;
            } else
            {
                canDash = true;
                newDashReal = timeNewDash;
            }
        }

        // Se realiza el desplazamiento del dashing en un tiempo determinado.
        if (isDashing)
        {
            if (dashTimeReal >= 0)
            {
                dashTimeReal -= Time.deltaTime;

                if (dashDirection != 0)
                {
                    rb.velocity = Vector2.right * dashSpeed * dashDirection;

                    if (Mathf.Abs(transform.position.x - lastImageXPos) > distanceBetweenImages)
                    {
                        PlayerImageAfterPool.Instance.GetFromPool();
                        lastImageXPos = transform.position.x;
                    }
                }
            }
            else
            {
                dashTimeReal = dashTime;
                isDashing = false;
            }
        }
    }
}
