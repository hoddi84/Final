using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorController : MonoBehaviour {

    public int degrees = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(MazeUtility.RotateOverSeconds(transform.gameObject, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.y + degrees, transform.rotation.z), 5f));
        }
	}
}
