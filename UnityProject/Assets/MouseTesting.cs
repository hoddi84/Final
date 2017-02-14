using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Makes it possible to move specific objects in the scene
 * through the map view, objects must be of tag "MovableObject"
 */
public class MouseTesting : MonoBehaviour {

    private Transform movableObject;
    private bool movableObjectCanMove = false;
    private bool movableObjectControlled = false;

    public Camera cam;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10)) {
                if (hit.transform.tag == "MovableObject" && !movableObjectControlled)
                {
                    movableObject = hit.transform;
                    movableObjectCanMove = true;
                    movableObjectControlled = true;
                }
            }

            if (movableObjectCanMove)
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = 15f;
                v3 = cam.ScreenToWorldPoint(v3);

                movableObject.transform.position = new Vector3(v3.x, movableObject.transform.position.y, v3.z);
            }
        } 

        if (Input.GetMouseButtonUp(0))
        {
            movableObjectCanMove = false;
            movableObjectControlled = false;
            movableObject = null;
        }
	}
}
