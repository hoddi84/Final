using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void ClickAction();
    public static event ClickAction OnKeyDownE;
    public static event ClickAction OnKeyUpE;
    public static event ClickAction OnKeyDownR;
    public static event ClickAction OnKeyUpR;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (OnKeyDownE != null)
            {
                OnKeyDownE();
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (OnKeyUpE != null)
            {
                OnKeyUpE();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (OnKeyDownR != null)
            {
                OnKeyDownR();
            }
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            if (OnKeyUpR != null)
            {
                OnKeyUpR();
            }
        }
	}
}
