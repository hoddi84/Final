using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject headDown;
    public GameObject headFollow;
    public HeadLookController controller;

    private bool followActivated = false;

	// Use this for initialization
	void Start () {

        controller.target = headDown.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E) && !followActivated)
        {
            followActivated = true;
            print("active");
        }
        else if (Input.GetKeyDown(KeyCode.E) && followActivated)
        {
            followActivated = false;
            print("deactive");
        }

        if (followActivated)
        {
            controller.target = headFollow.transform.position;
        }
        else
        {
            controller.target = headDown.transform.position;
        }
	}
}
