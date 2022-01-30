using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    public float verticalCorrection = 0;
    public float verticalCorrectionLookinUp = 0;
    public bool isShotgun;

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
            lastVerticalAxis = 1 + verticalCorrectionLookinUp;
            if (horizontalAxis == 0)
            {
                gradeToRotate = 90;
            }
            else
            {
                gradeToRotate = 45;
            }
        }
        else if (verticalAxis < 0)
        {
            lastVerticalAxis = -1 + verticalCorrectionLookinUp;

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
            gradeToRotate = -7;
        }

        if (horizontalAxis != 0 || lastVerticalAxis == 0)
        {
            lastHorizontalAxis = 1;
        }
        else
        {
            lastHorizontalAxis = 0;
        }


        if (verticalAxis < 0)
        {
            transform.localPosition = new Vector3(0.41f, 0.4f, 0);
        } else if (verticalAxis > 0)
        {
            transform.localPosition = new Vector3(0.525f, 1f, 0);
        } else
        {
            if (isShotgun)
            {
                transform.localPosition = new Vector3(0.853f, 0.627f, 0);
            }
            else
            {
                transform.localPosition = new Vector3(0.572f, 0.779f, 0);
            }
            
        }

        //firePoint.transform.localPosition = new Vector3(lastHorizontalAxis, lastVerticalAxis == 0 ? verticalCorrection : lastVerticalAxis, 0);
        transform.localRotation = Quaternion.Euler(0, 0, gradeToRotate);

    }
}
