﻿using System.Collections;
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

    [Header("Interaction Sounds")]
    public AudioClip doorHandleClip;
    public AudioClip doorCloseClip;
 
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
     * TODO::
     * Need to clean up here, fix the controller logic.
     * Rename the variables accordingly.
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
                float rotation = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateDegrees;
                float timeOpen = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateTimeOpen;
                float timeClose = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateTimeClose;
                bool direction = doorHandle.gameObject.GetComponent<MazeDoorController>().openHandleOutwards;
                MazeDoorController controller = doorHandle.gameObject.GetComponent<MazeDoorController>();
                StartCoroutine(MazeUtility.RotateOverSeconds(doorHandleClip, doorCloseClip, controller, door, rotation, timeOpen, timeClose, direction));
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
            }

        }
    }
}
