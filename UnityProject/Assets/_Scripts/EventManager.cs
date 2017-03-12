using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void ClickedEventHandler();

    public static event ClickedEventHandler MouseDownRight;
    public static event ClickedEventHandler MouseDownPressedRight;
    public static event ClickedEventHandler MouseUpRight;

    public static event ClickedEventHandler MouseDownLeft;
    public static event ClickedEventHandler MouseDownPressedLeft;
    public static event ClickedEventHandler MouseUpLeft;

    public static event ClickedEventHandler KeyE_Down;
    public static event ClickedEventHandler KeyE_Up;


    void Update()
    {
        // Left Mouse Button
        if (Input.GetMouseButtonDown(0))
        {
            if (MouseDownLeft != null)
            {
                MouseDownLeft();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (MouseDownPressedLeft !=null)
            {
                MouseDownPressedLeft();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (MouseUpLeft != null)
            {
                MouseUpLeft();
            }
        }

        // Right Mouse Button
        if (Input.GetMouseButtonDown(1))
        {
            if (MouseDownRight != null)
            {
                MouseDownRight();
            }
        }
        else if (Input.GetMouseButton(1))
        {
            if (MouseDownPressedRight != null)
            {
                MouseDownPressedRight();
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (MouseUpRight != null)
            {
                MouseUpRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (KeyE_Down != null)
            {
                KeyE_Down();
            }
        }
        else if (Input.GetKeyUp(KeyCode.E)) 
        {
            if (KeyE_Up != null)
            {
                KeyE_Up();
            }
        }
    }

}



