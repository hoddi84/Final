using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    [Header("Transition Triggers")]
    public GameObject TransitionFirst;

    private BoxCollider transitionFirstCollider;

	// Use this for initialization
	void Start () {

        transitionFirstCollider = TransitionFirst.GetComponent<BoxCollider>();

        /*
         * We want to disable the collider until the player has
         * moved into the VR area so the collider won't be accidentally
         * triggered.
         */
        transitionFirstCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E))
        {
            transitionFirstCollider.enabled = true;
            print("TransitionFirst enabled");
        }
	}
}
