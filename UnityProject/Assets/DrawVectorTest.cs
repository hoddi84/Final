using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectorTest : MonoBehaviour
{

    public Transform end;
    public Transform start;

    public Transform controller;

    public Transform movable;

    Vector3 dir;
    Vector3 controllerStart;
    Vector3 controllerEnd;

    float lerpValue;

    // Use this for initialization
    void Start()
    {
        dir = end.position - start.position;

        lerpValue = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 perendicularToLine = Vector3.Project(controller.position, dir.normalized);

        Vector3 lineFformBegin = Vector3.Project(controller.position, dir.normalized);

        /*
         * A value that tells us where we are between start and end, and the value is 
         * from 0 to 1.
         */
        lerpValue = Vector3.Distance(start.position, lineFformBegin) / dir.magnitude;

        Debug.DrawLine(start.position, controller.position, Color.blue, 200);
        Debug.DrawLine(end.position, controller.position, Color.blue, 200);
        Debug.DrawLine(controller.position, perendicularToLine, Color.green, 200);
        Debug.DrawLine(lineFformBegin, start.position, Color.black, 200);

        if (lerpValue >= 1)
        {
            lerpValue = 1;
        }

        /*
         * Check if the angle from the (controller - start) and (start - end) is greater
         * than 90 degrees, then we can know if the have gone too far.
         */
        if (Vector3.Dot(dir.normalized, (controller.position - start.position).normalized) <= 0)
        {
            print("too much");
            lerpValue = 0;
        }

        movable.position = Vector3.Lerp(start.position, end.position, lerpValue);


    }
}
