using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int lenght;
    public LineRenderer line;
    public Vector3[] segments;
    public Vector3[] segmentsV;

    public Transform targetDir;
    public float targetDis;
    public float smoothMovement;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;

    public Transform wigglePoint;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = lenght;
        segments = new Vector3[lenght];
        segmentsV = new Vector3[lenght];

    }

    // Update is called once per frame
    void Update()
    {

        wigglePoint.localRotation = Quaternion.Euler(0,0,Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segments[0] = targetDir.position;

        for (int i = 1; i < segments.Length; i++)
        {
            segments[i] = Vector3.SmoothDamp(segments[i], segments[i - 1] + targetDir.right * targetDis, ref segmentsV[i], smoothMovement + i / trailSpeed);
        }
        line.SetPositions(segments);
    }
}
