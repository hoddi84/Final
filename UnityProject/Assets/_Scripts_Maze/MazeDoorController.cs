using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorController : MonoBehaviour {

    [Header("Door Settings")]
    public GameObject doorObject;
    public GameObject frameObject;
    public int rotateDegrees = 20;
    public float rotateTimeOpen = 5f;
    public float rotateTimeClose = 5f;
    public bool openHandleOutwards = true;
    public bool canInteract = true;

    /*
     * The angle between the door and the frame, so we can
     * tell if the door is open or closed.
     */
    private float angleDiff;

    [Header("Sounds")]
    public AudioClip handle;
    public AudioClip close;

    [Header("Connected Doors")]
    public GameObject[] connectedDoors;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) && canInteract)
        {
            canInteract = false;
            StartCoroutine(MazeUtility.RotateOverSeconds(handle, close, this, doorObject, rotateDegrees, rotateTimeOpen, rotateTimeClose, openHandleOutwards));
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

    /*
     * Update the connecting doors, such that their rotation and their 
     * direction will be the same, as the previous door has changed.
     */
    public void UpdateDoorRotation(GameObject changedDoor)
    {
        float rotation = changedDoor.transform.localEulerAngles.y;
        bool direction = changedDoor.GetComponentInChildren<MazeDoorController>().openHandleOutwards;
        foreach (GameObject door in connectedDoors)
        {
            door.transform.localEulerAngles = new Vector3(0, rotation, 0);
            door.GetComponentInChildren<MazeDoorController>().openHandleOutwards = direction;

        }
    }

    /*
     * Return true if the door is open, e.g. if the y-angle difference
     * between the door and the doorframe is greater then 0.1.
     */
    public bool DoorOpen()
    {
        float angleDoor = doorObject.transform.localEulerAngles.y;
        float angleFrame = frameObject.transform.localEulerAngles.y;
        angleDiff = Mathf.Abs(angleDoor - angleFrame);

        if (angleDiff > 0.1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
