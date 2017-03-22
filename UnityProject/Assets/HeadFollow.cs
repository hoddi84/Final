using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour {

    private HeadLookController lookController;
    public Transform whereToLook;

	// Use this for initialization
	void Start () {

        lookController = GetComponent<HeadLookController>();
        lookController.target = whereToLook.position;
	}
	
	// Update is called once per frame
	void Update () {

        lookController.target = whereToLook.position;
	}
}
