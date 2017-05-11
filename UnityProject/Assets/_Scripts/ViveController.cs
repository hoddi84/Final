using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private bool canInteract;
    private bool holdingObject;

    private bool testActivated;

    private GameObject interactedObject;

    private SteamVR_TrackedController controller;
    private MazeDoorController mazeDoorController;

    [Header("Interaction Sounds")]
    public AudioClip doorHandleClip;
    public AudioClip doorCloseClip;
    public AudioClip doorLockedClip;
    public AudioClip vinylNeedleSound;
    public AudioClip vinylMusicTrack1;

    [Header("Elevator Settings")]
    public GameObject elevatorFloor;
    public GameObject elevatorEnd;
    public GameObject elevatorBegin;
    public GameObject rig;
    private float elevatorTime = 15f;
    private bool firstFloor = true;
 
    void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.TriggerUnclicked += HandleTriggerUnclicked;
        controller.Gripped += HandleGripped;
        controller.Ungripped += HandleUngripped;
    }

    void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
        controller.TriggerUnclicked -= HandleTriggerUnclicked;
        controller.Gripped -= HandleGripped;
        controller.Ungripped -= HandleUngripped;
    }

    void Update()
    {
        /*
         * Logic whgich we use to test our elevator
         */
         if (testActivated && firstFloor)
        {
            testActivated = false;
            firstFloor = false;
            StartCoroutine(MazeUtility.MoveOverSeconds(elevatorFloor, elevatorEnd.transform.position, elevatorTime, true, rig, true, 1, controller));
        }
         else if (testActivated && !firstFloor)
        {
            testActivated = false;
            firstFloor = true;
            StartCoroutine(MazeUtility.MoveOverSeconds(elevatorFloor, elevatorBegin.transform.position, elevatorTime, true, rig, true, 1, controller));
        }

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
                    /*
                     * If the door is locked, play the locked sound
                     * and dereference.
                     */
                    if (mazeDoorController.doorIsLocked)
                    {
                        MazeUtility.PlaySound(mazeDoorController, doorLockedClip);
                        interactedObject = null;
                        mazeDoorController = null;
                    }
                    /*
                     * If the door is open, open the door.
                     */
                    else
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
    }

    void HandleGripped(object sender, ClickedEventArgs e)
    {
        testActivated = true;
    }

    void HandleUngripped(object sender, ClickedEventArgs e)
    {
        testActivated = false;
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
                canInteract = false;
                StartCoroutine(MazeUtility.TriggerVibration(controller, 1, .1f));
                interactedObject = other.gameObject;
                mazeDoorController = other.GetComponent<MazeDoorController>();
            }
        }
        else if (other.gameObject.tag == "VinylPlayer")
        {
            if (canInteract)
            {
                canInteract = false;
                StartCoroutine(MazeUtility.TriggerVibration(controller, 1, 1f));
                StartCoroutine(MazeUtility.PlayVinyl(vinylNeedleSound, vinylMusicTrack1, other.gameObject));
            }
        }

        if (other.gameObject.tag == "Wall")
        {
            MazeUtility.TriggerContinuousVibration(controller, .5f);
        }
    }
}
