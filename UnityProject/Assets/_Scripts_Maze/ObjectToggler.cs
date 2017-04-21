using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Executre in Edit mode so that we can hide the
 * normalState directly from the inspector.
 */
[ExecuteInEditMode]
public class ObjectToggler : MonoBehaviour {

    private bool switched = false;

    [Header("Editor Only Changes")]
    public bool hideOriginalState = false;
    public bool showDoorState = false;
    public bool showDoor = false;

    [Header("Maze Controller")]
    public MazeController controller;

    [Header("Original State")]
    public GameObject[] normalState;

    [Header("Possible States")]
    public GameObject doorState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E) && !switched && controller.place2Active)
        {
            foreach (GameObject obj in normalState)
            {
                obj.SetActive(false);
            }
            doorState.SetActive(true);
            switched = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && switched && controller.place2Active)
        {
            foreach (GameObject obj in normalState)
            {
                obj.SetActive(true);
            }
            doorState.SetActive(false);
            switched = false;
        }

        /*
         * Do not run this code while in play mode.
         * RUNNING IN PLAY MODE AND EDIT MODE
         */
        if (!Application.isPlaying || Application.isPlaying)
        {
            if (hideOriginalState)
            {
                foreach (GameObject obj in normalState)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                foreach (GameObject obj in normalState)
                {
                    obj.SetActive(true);
                }
            }

            if (showDoorState)
            {
                doorState.SetActive(true);
            }
            else
            {
                doorState.SetActive(false);
            }

            if (showDoor)
            {
                foreach (GameObject obj in normalState)
                {
                    obj.SetActive(false);
                    doorState.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject obj in normalState)
                {
                    obj.SetActive(true);
                    doorState.SetActive(false);
                }
            }
        }
	}
}
