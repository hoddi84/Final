using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {

    public GameObject start;
    public GameObject end;

    private Vector3 dir;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        dir = start.transform.position - end.transform.position;
        Debug.DrawLine(start.transform.position, end.transform.position, Color.green);
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(start.transform.position, dir,100f))
        {
            print("hit");
        }
    }
}
