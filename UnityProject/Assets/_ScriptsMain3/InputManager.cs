using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public bool raycastHitRight;
    public bool raycastHitLeft;
    public bool mouseDownRight;
    public bool mouseDownLeft;

    public Camera mapCamera;

    private GameObject selectedObject;

    void OnEnable()
    {
        InputHandler.MouseLeftRaycastHit += RaycastLeft;
        InputHandler.MouseRightRaycastHit += RaycastRight;

        InputHandler.MouseDownRight += MouseDownRight;
        InputHandler.MouseDownLeft += MouseDownLeft;

        InputHandler.MouseUpRight += MouseUpRight;
        InputHandler.MouseUpLeft += MouseUpLeft;
    }

    void OnDisable()
    {
        InputHandler.MouseLeftRaycastHit -= RaycastLeft;
        InputHandler.MouseRightRaycastHit -= RaycastRight;

        InputHandler.MouseDownRight -= MouseDownRight;
        InputHandler.MouseDownLeft -= MouseDownLeft;

        InputHandler.MouseUpRight -= MouseUpRight;
        InputHandler.MouseUpLeft -= MouseUpLeft;
    }

    /*
     * If we hit a collider with the left mouse button
     * this is called. The object's collider we hit will
     * be our selectedObject.
     */
    void RaycastLeft(GameObject obj)
    {
        raycastHitLeft = true;
        selectedObject = obj;
    }

    void RaycastRight(GameObject obj)
    {
        raycastHitRight = true;
    }

    void MouseDownRight()
    {
        mouseDownRight = true;
    }

    void MouseDownLeft()
    {
        mouseDownLeft = true;
    }

    void MouseUpLeft()
    {
        mouseDownLeft = false;
        raycastHitLeft = false;
    }

    void MouseUpRight()
    {
        mouseDownRight = false;
        raycastHitRight = false;
    }

    void Update()
    {
        /*
         * We hit a collider with the left mouse button. The
         * object we hit is now our selectedObject.
         */
        if (raycastHitLeft)
        {
            if (selectedObject != null)
            {
                if (selectedObject.tag == "Player")
                {
                    Vector3 v3 = Input.mousePosition;
                    v3.z = 15f;
                    v3 = mapCamera.ScreenToWorldPoint(v3);

                    selectedObject.transform.position = new Vector3(v3.x, selectedObject.transform.position.y, v3.z);
                }
            }
        }
        else
        {
            selectedObject = null;
        }
    }
}
