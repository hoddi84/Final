using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMechanics : MonoBehaviour {

    public Sprite topFloorSprite;
    public Sprite belowFloorSprite;

    public GameObject belowFloor;

    [Header("Elevator Settings")]
    public GameObject elevatorFloor;
    public GameObject elevatorEnd;
    public GameObject elevatorBegin;
    public GameObject rig;
    private float elevatorTime = 15f;

    private bool elevatorIsUp = true;

    public VIVEControllerManager controllerManager;

    /*
     * Still working on this. Need to make it unavailable to any actions
     * while the elevator is still moving.
     */
    public void ActivateElevator()
    {
        if (elevatorIsUp)
        {
            StartCoroutine(MazeUtility.MoveOverSeconds(elevatorFloor, elevatorEnd.transform.position, elevatorTime, true, rig, true, controllerManager));
            elevatorIsUp = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = belowFloorSprite;
            belowFloor.SetActive(true);
        }
        else if (!elevatorIsUp)
        {
            StartCoroutine(MazeUtility.MoveOverSeconds(elevatorFloor, elevatorBegin.transform.position, elevatorTime, true, rig, true, controllerManager));
            elevatorIsUp = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = topFloorSprite;
            belowFloor.SetActive(false);
        }
    }
}
