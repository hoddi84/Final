using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour {

    void OnEnable()
    {
        EventManager.MouseDownLeft += MouseDownLeft;
        EventManager.MouseUpLeft += MouseUpLeft;
        EventManager.MouseDownPressedLeft += MouseDownPressedLeft;

        EventManager.MouseDownRight += MouseDownRight;
        EventManager.MouseUpRight += MouseUpRight;
        EventManager.MouseDownPressedRight += MouseDownPressedRight;
    }

    void OnDisable()
    {
        EventManager.MouseDownLeft -= MouseDownLeft;
        EventManager.MouseUpLeft -= MouseUpLeft;
        EventManager.MouseDownPressedLeft -= MouseDownPressedLeft;

        EventManager.MouseDownRight -= MouseDownRight;
        EventManager.MouseUpRight -= MouseUpRight;
        EventManager.MouseDownPressedRight -= MouseDownPressedRight;
    }

    void MouseDownLeft()
    {
        print("Left mouse button pressed down");
    }

    void MouseUpLeft()
    {
        print("Left mouse button released");
    }

    void MouseDownPressedLeft()
    {
        print("Left mouse button held down");
    }

    void MouseDownRight()
    {
        print("Right mouse button pressed down");
    }

    void MouseUpRight()
    {
        print("Right mouse button released");
    }

    void MouseDownPressedRight()
    {
        print("Right mouse button held down");
    }
}
