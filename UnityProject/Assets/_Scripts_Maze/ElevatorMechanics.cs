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

    public bool elevatorIsMoving = false;

    public VIVEControllerManager controllerManager;

    /*
     * Still working on this. Need to make it unavailable to any actions
     * while the elevator is still moving.
     */
    public void ActivateElevator()
    {
        if (elevatorIsUp)
        {
            elevatorIsMoving = true;
            StartCoroutine(MazeUtility.MoveOverSeconds(this, elevatorFloor, elevatorEnd.transform.position, elevatorTime, true, rig, true, controllerManager, true));
            elevatorIsUp = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = belowFloorSprite;
        }
        else if (!elevatorIsUp)
        {
            elevatorIsMoving = true;
            StartCoroutine(MazeUtility.MoveOverSeconds(this, elevatorFloor, elevatorBegin.transform.position, elevatorTime, true, rig, true, controllerManager, false));
            elevatorIsUp = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = topFloorSprite;
        }
    }
}
