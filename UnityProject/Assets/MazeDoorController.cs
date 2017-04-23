using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorController : MonoBehaviour {

    [Header("Door Settings")]
    public GameObject doorObject;
    public int rotateDegrees = 20;
    public float rotateTime = 5f;
    public bool openHandleOutwards = true;

    public bool canInteract = true;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) && canInteract)
        {
            canInteract = false;
            StartCoroutine(MazeUtility.RotateOverSeconds(this, doorObject, rotateDegrees, rotateTime, openHandleOutwards));
            if (openHandleOutwards)
            {
                openHandleOutwards = false;
            }
            else
            {
                openHandleOutwards = true;
            }
        }
	}
}
