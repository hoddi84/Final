using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderValues : MonoBehaviour {

    /*
     * Used for objects who can be manipulated with the slider,
     * we need to remember the values affected by the slider, e.g.
     * the intensity of a light or the rotation of a door so that it doesn't
     * screw up when we change between controllable objects.
     */
    float sliderValue = 0;

    /*
     * lightsOn = 1, means the lights are currently turned on.
     */ 
    float lightsOn = 1;

    /*
     * We need to check if the doors are closed by comparing the frame's 
     * rotation to the door's rotation. We must assign this script as well
     * to all doors.
     */
    public Transform door;
    public Transform frame;

    public void SetSliderValue(float value)
    {
        sliderValue = value;
        lightsOn = value;
    }

    public float GetSliderValue()
    {
        return sliderValue;
    }

    public float LightsOn()
    {
        return lightsOn;
    }

    public bool DoorClosed()
    {
        /*
         * If the rotationDiff is 0, we know that the door and the frame
         * are with the same rotation, hence the doors must be closed.
         */
        float rotationDiff;
        rotationDiff = Mathf.Abs(door.rotation.y - frame.rotation.y);
        if (rotationDiff < 0.05)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
