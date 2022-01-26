using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public GameObject body;
    public GameObject legs;

    private Animator bodyAnimator;
    private Animator legsAnimator;

    private float verticalMovement;
    private float horizontalMovement;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        bodyAnimator = body.GetComponent<Animator>();
        legsAnimator = legs.GetComponent<Animator>();
        verticalMovement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        bodyAnimator.SetFloat("Looking", verticalMovement);

        isRunning = horizontalMovement != 0 ? true : false;

        legsAnimator.SetBool("isRunning", isRunning);
    }
}
