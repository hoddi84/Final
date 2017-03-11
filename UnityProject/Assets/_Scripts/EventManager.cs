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
        if (Input.GetMouseButtonDown(0))
        {
            if (MouseDownLeft != null)
            {
                MouseDownLeft();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (MouseUpLeft != null)
            {
                MouseUpLeft();
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



