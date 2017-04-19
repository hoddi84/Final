using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public delegate void RaycastEventHandler(GameObject obj);
    public delegate void MouseEventHandler();

    public static event RaycastEventHandler MouseRightRaycastHit;
    public static event RaycastEventHandler MouseLeftRaycastHit;

    public static event MouseEventHandler MouseDownRight;
    public static event MouseEventHandler MouseUpRight;

    public static event MouseEventHandler MouseDownLeft;
    public static event MouseEventHandler MouseUpLeft;

    public Camera mapCamera;
	
	// Update is called once per frame
    void Update()
    {
        /*
         * Mouse input. 
         */
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                if (MouseLeftRaycastHit != null)
                {
                    MouseLeftRaycastHit(hit.transform.gameObject);
                }
            }
            else
            {
                if (MouseDownLeft != null)
                {
                    MouseDownLeft();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                if (MouseRightRaycastHit != null)
                {
                    MouseRightRaycastHit(hit.transform.gameObject);
                }
            }
            else
            {
                if (MouseDownRight != null)
                {
                    MouseDownRight();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (MouseUpLeft != null)
            {
                MouseUpLeft();
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (MouseUpRight != null)
            {
                MouseUpRight();
            }
        }
    }
}
