using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private bool canInteract;
    private bool holdingObject;

    private GameObject interactedObject;

    private SteamVR_TrackedController controller;
    private MazeDoorController mazeDoorController;

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

    void Update()
    {

        /*
         * Logic for picking up pickable objects. 
         */
        if (interactedObject != null)
        {
            if (interactedObject.tag == "Pickable")
            {
                if (holdingObject)
                {
                    interactedObject.transform.parent = transform;
                    interactedObject.GetComponent<Rigidbody>().isKinematic = true;
                    interactedObject.GetComponent<Rigidbody>().useGravity = false;
                }
                else
                {
                    interactedObject.transform.parent = null;
                    interactedObject.GetComponent<Rigidbody>().isKinematic = false;
                    interactedObject.GetComponent<Rigidbody>().useGravity = true;
                    interactedObject = null;
                }
            }

            /*
             * Logic for handling openable doors.
             */
            else if (interactedObject.tag == "VIVEDoor")
            {
                if (mazeDoorController != null)
                {
                    if (mazeDoorController.canInteract)
                    {
                        mazeDoorController.canInteract = false;
                        GameObject door = mazeDoorController.doorObject;
                        GameObject doorHandle = interactedObject.gameObject;

                        float rotation = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateDegrees;
                        float timeOpen = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateTimeOpen;
                        float timeClose = doorHandle.gameObject.GetComponent<MazeDoorController>().rotateTimeClose;
                        bool direction = doorHandle.gameObject.GetComponent<MazeDoorController>().openHandleOutwards;

                        StartCoroutine(MazeUtility.RotateOverSeconds(doorHandleClip, doorCloseClip, mazeDoorController, door, rotation, timeOpen, timeClose, direction));

                        if (direction)
                        {
                            mazeDoorController.openHandleOutwards = false;
                        }
                        else
                        {
                            mazeDoorController.openHandleOutwards = true;
                        }

                        doorHandle = null;
                        door = null;
                        interactedObject = null;
                        mazeDoorController = null;
                    }
                }
            }
        }
    }

    void HandleTriggerClicked(object sender, ClickedEventArgs e) 
    {
        canInteract = true;
    }

    void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        canInteract = false;
        holdingObject = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            if (canInteract)
            {
                canInteract = false;
                interactedObject = other.gameObject;
                holdingObject = true;
            }
        }

        else if (other.gameObject.tag == "VIVEDoor")
        {
            if (canInteract)
            {
                StartCoroutine(MazeUtility.TriggerVibration(controller, 1, 1));
                canInteract = false;
                interactedObject = other.gameObject;
                mazeDoorController = other.GetComponent<MazeDoorController>();
            }
        }

        // TODO: Get all the walls compatible.
        if (other.gameObject.tag == "Wall")
        {
            MazeUtility.TriggerContinuousVibration(controller, 1);
        }

        //SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse(3999);
    }
}
