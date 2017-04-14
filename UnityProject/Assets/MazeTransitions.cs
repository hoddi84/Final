using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTransitions : MonoBehaviour {

    [Header("Transitions")]
    public GameObject transitionFrom;
    public GameObject transitionBetween;
    public GameObject transitionTo;

	// Use this for initialization
	void Start () {

        /*
         * Make sure the transition we can move towards is disabled.
         */
        transitionTo.SetActive(false);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*
             * When we enter the trigger we want to disable the transitionFrom
             * gameObject and enable the transitionTo gameObject. 
             */
            transitionFrom.SetActive(false);
            transitionTo.SetActive(true);
        }
    }
}
