using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour {

    private bool switched = false;

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
	}
}
