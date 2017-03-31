using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public bool raycastHitRight;
    public bool raycastHitLeft;
    public bool mouseDownRight;
    public bool mouseDownLeft;

    public Text textObject;

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

    void RaycastLeft(GameObject obj)
    {
        print("Hit Collider (left mouse), tag: " + obj.transform.tag);
        raycastHitLeft = true;
        UtilityManager.DisplayMessage(obj, textObject);
    }

    void RaycastRight(GameObject obj)
    {
        print("Hit Collider (right mouse), tag: " + obj.transform.tag);
        raycastHitRight = true;
    }

    void MouseDownRight()
    {
        print("Mouse Down (right)");
        mouseDownRight = true;
    }

    void MouseDownLeft()
    {
        print("Mouse Down (left");
        mouseDownLeft = true;
    }

    void MouseUpLeft()
    {
        print("Mouse Up (left)");
        mouseDownLeft = false;
        raycastHitLeft = false;
    }

    void MouseUpRight()
    {
        print("Mouse Up (right)");
        mouseDownRight = false;
        raycastHitRight = false;
    }
}
