using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointController : MonoBehaviour
{

    public GameObject firePoint;

    float lastHorizontalAxis;
    float lastVerticalAxis;
    // Start is called before the first frame update
    void Start()
    {
        lastHorizontalAxis = 1;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float gradeToRotate = 0;

        if (verticalAxis > 0)
        {
            lastVerticalAxis = 1;
            if (horizontalAxis == 0)
            {
                gradeToRotate = 90;
            } else
            {
                gradeToRotate = 45;
            }
        }
        else if (verticalAxis < 0)
        {
            lastVerticalAxis = -1;

            if (horizontalAxis == 0)
            {
                gradeToRotate = 270;
            }
            else
            {
                gradeToRotate = 315;
            }
        }
        else 
        {
            lastVerticalAxis = 0;
            gradeToRotate = 0;
        }

        if (horizontalAxis != 0 || lastVerticalAxis == 0)
        {
            lastHorizontalAxis = 1;
        } else
        {
            lastHorizontalAxis = 0;
        }

        

        firePoint.transform.localPosition = new Vector3(lastHorizontalAxis, lastVerticalAxis, 0);
        //firePoint.transform.eulerAngles = new Vector3(0,0,gradeToRotate);
        firePoint.transform.localRotation = Quaternion.Euler(0, 0, gradeToRotate);

    }
}
