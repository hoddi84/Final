using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {

    public delegate void InteractEventHandler();

    public static event InteractEventHandler MouseRightRaycastHit;
    public static event InteractEventHandler MouseLeftRaycastHit;

    public Camera overViewCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = overViewCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                if (MouseLeftRaycastHit != null)
                {
                    MouseLeftRaycastHit();
                }
            }
        }
    }
}
