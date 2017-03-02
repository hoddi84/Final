using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderValues : MonoBehaviour {

    float sliderValue = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSliderValue(float value)
    {
        sliderValue = value;
    }

    public float GetSliderValue()
    {
        return sliderValue;
    }
}
