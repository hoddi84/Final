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
    float sliderValue = 1;

    public void SetSliderValue(float value)
    {
        sliderValue = value;
    }

    public float GetSliderValue()
    {
        return sliderValue;
    }
}
