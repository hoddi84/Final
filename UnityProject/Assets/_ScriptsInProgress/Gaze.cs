using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {

    private Vector3 lookDir;

    bool gazing = false;
    float timeGazing = 0f;

    bool shortGaze = false;
    bool longGaze = false;

	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {
        if (gazing)
        {
            timeGazing += Time.deltaTime;

            if (timeGazing <= 2 && timeGazing >= 1)
            {
                shortGaze = true;
            }
            if (timeGazing >= 4f)
            {
                longGaze = true;
            }
        }
        else
        {
            timeGazing = 0f;
            shortGaze = false;
            longGaze = false;
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray r = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(r, out hit, 5f))
        {
            gazing = true;
        }
        else
        {
            gazing = false;
        }
    }
}
