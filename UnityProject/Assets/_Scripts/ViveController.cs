using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private bool canPickUp;
    private bool holding;

    private bool triggerDoor = false;
    private bool once = false;

    private GameObject objBeingHeld;

    private GameObject doorHandle;
    private GameObject door;

    private SteamVR_TrackedController controller;
 
    void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.TriggerUnclicked += HandleTriggerUnclicked;
    }

    void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
        controller.TriggerUnclicked -= HandleTriggerUnclicked;
    }

    /*
     * Need to clean up here, fix the controller logic.
     */
    void Update()
    {
        /*
        if (holding)
        {
            if (objBeingHeld != null)
            {
                objBeingHeld.transform.parent = transform;
                objBeingHeld.GetComponent<Rigidbody>().isKinematic = true;
                objBeingHeld.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        else
        {
            if (objBeingHeld != null)
            {
                objBeingHeld.transform.parent = null;
                objBeingHeld.GetComponent<Rigidbody>().isKinematic = false;
                objBeingHeld.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        */

        if (triggerDoor)
        {
            if (doorHandle != null && door != null)
            {
                print("reached here too");
                float rotation = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateDegrees;
                float time = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateTime;
                bool direction = doorHandle.gameObject.GetComponent<MazeDoorController>().openHandleOutwards;
                bool doorOpen = doorHandle.gameObject.GetComponent<MazeDoorController>().doorOpen;
                StartCoroutine(MazeUtility.RotateOverSeconds(door, rotation, time, direction));
                triggerDoor = false;
                doorHandle = null;
                door = null;
            }
        }
    }

    void HandleTriggerClicked(object sender, ClickedEventArgs e) 
    {
        canPickUp = true;
    }

    void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        canPickUp = false;
        holding = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickable" && canPickUp)
        {
            objBeingHeld = other.gameObject;
            holding = true;
        }

        else if (other.gameObject.tag == "VIVEDoor" && canPickUp)
        {
            if (!once)
            {
                door = other.gameObject.GetComponent<MazeDoorController>().doorObject;
                doorHandle = other.gameObject;
                triggerDoor = true;
                once = true;
                print("reached here");
            }

        }
    }
}
