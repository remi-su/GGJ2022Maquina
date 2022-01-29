using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer linerend;
    public Vector3[] segmentposes;
    private Vector3[] segmentv;

    public Transform targetdir;
    public float targetdist;
    public float smoothspeed;

    public float wigglespeed;
    public float wigglemagnitude;
    public Transform wiggledir;

    public Transform[] bodyparts;
    // Start is called before the first frame update
    void Start()
    {
        linerend.positionCount = length;
        segmentposes = new Vector3[length];
        segmentv = new Vector3[length];
        reset_pos();    
    }

    // Update is called once per frame
    void Update()
    {

        wiggledir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wigglespeed) * wigglemagnitude);

        segmentposes[0] = targetdir.position;
        for (int i = 1; i<segmentposes.Length; i++)
        {
            Vector3 targetpos = segmentposes[i -1] + (segmentposes[i] - segmentposes[i - 1]).normalized * targetdist;
            segmentposes[i] = Vector3.SmoothDamp(segmentposes[i], targetpos, ref segmentv[i], smoothspeed);
            bodyparts[i - 1].transform.position = segmentposes[i];
        }
        linerend.SetPositions(segmentposes);
    }

    private void reset_pos()
    {
        segmentposes[0] = targetdir.position;
        for (int i = 1; i < length; i++)
        {
            segmentposes[i] = segmentposes[i - 1] + targetdir.right * targetdist;
        }
        linerend.SetPositions(segmentposes);
    }
}
