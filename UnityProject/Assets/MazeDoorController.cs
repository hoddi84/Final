using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorController : MonoBehaviour {

    [Header("Door Settings")]
    public GameObject doorObject;
    public int rotateDegrees = 20;
    public float rotateTime = 5f;
    public bool openHandleOutwards = true;

    public bool doorOpen = false;
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.R) && !doorOpen)
        {
            StartCoroutine(MazeUtility.RotateOverSeconds(doorObject, rotateDegrees, rotateTime, openHandleOutwards));
            openHandleOutwards = false;
            doorOpen = true;
            print("first");
        }
        else if (Input.GetKeyDown(KeyCode.R) && doorOpen)
        {
            StartCoroutine(MazeUtility.RotateOverSeconds(doorObject, rotateDegrees, rotateTime, openHandleOutwards));
            openHandleOutwards = true;
            doorOpen = false;
            print("second");
        }
	}
}
