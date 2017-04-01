using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActions : MonoBehaviour 
{

    private List<Actions> actions;

	// Use this for initialization
	void Start () 
	{
        actions = new List<Actions>();
        actions.Add(Actions.Close);
        actions.Add(Actions.Open);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public List<Actions> GetActions()
    {
        return actions;
    }
}
