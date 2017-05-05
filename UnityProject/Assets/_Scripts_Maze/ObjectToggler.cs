using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour {

    [Header("Toggle States")]
    public bool showDoorState = false;

    [Header("Original State")]
    public GameObject[] normalState;

    [Header("Possible States")]
    public GameObject doorState;
	
	// Update is called once per frame
	void Update () {

        if (showDoorState)
        {
            foreach (GameObject obj in normalState)
            {
                obj.SetActive(false);
            }
            doorState.SetActive(true);
        }
        else
        {
            foreach (GameObject obj in normalState)
            {
                obj.SetActive(true);
            }
            doorState.SetActive(false);
        }
	}

    public void ShowDoor(bool condition)
    {
        if (condition)
        {
            showDoorState = true;
        }
        else
        {
            showDoorState = false;
        }
    }
}
