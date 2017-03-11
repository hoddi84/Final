using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void ClickedEventHandler();

    public static event ClickedEventHandler MouseDownRight;
    public static event ClickedEventHandler MouseUpRight;
    public static event ClickedEventHandler MouseDownLeft;
    public static event ClickedEventHandler MouseUpLeft;

    public static event ClickedEventHandler KeyE_Down;
    public static event ClickedEventHandler KeyE_Up;
    public static event ClickedEventHandler KeyE_Pressed;

}
