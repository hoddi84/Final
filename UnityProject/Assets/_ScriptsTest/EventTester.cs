using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour {

    void OnEnable()
    {
        EventManager.MouseDownLeft += MouseDownLeft;
        EventManager.MouseUpLeft += MouseUpLeft;
    }

    void OnDisable()
    {
        EventManager.MouseDownLeft -= MouseDownLeft;
        EventManager.MouseUpLeft -= MouseUpLeft;
    }

    void MouseDownLeft()
    {
        print("Left mouse button pressed down");
    }

    void MouseUpLeft()
    {
        print("Left mouse button released");
    }
}
