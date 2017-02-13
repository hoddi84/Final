using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Makes it possible to move specific objects in the scene
 * through the map view, objects must be of tag "Pickable"
 */
public class MouseTesting : MonoBehaviour {

    public GameObject pickableCube;
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

            if (Physics.Raycast(ray, out hit, 100)) {
                if (hit.transform.tag == "Pickable")
                {

                    Vector3 v3 = Input.mousePosition;
                    v3.z = 10f;
                    v3 = cam.ScreenToWorldPoint(v3);

                    hit.transform.position = new Vector3(v3.x, hit.transform.position.y, v3.z);
                }
            }
        } 

	}
}
