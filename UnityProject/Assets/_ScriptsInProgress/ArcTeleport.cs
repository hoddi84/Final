using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcTeleport : MonoBehaviour 
{
    bool show = false;

    private Valve.VR.InteractionSystem.ArcTest arc;
    private SteamVR_TrackedController controller;

    void OnEnable()
    {
        arc = GetComponent<Valve.VR.InteractionSystem.ArcTest>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.PadClicked += HandlePadClicked;
    }

    void OnDisable()
    {
        controller.PadUnclicked -= HandlePadUnclicked;
    }

    void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        show = true;
    }

    void HandlePadUnclicked(object sender, ClickedEventArgs e)
    {
        show = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (show)
        {
            RaycastHit hitInfo;
            arc.SetArcData(transform.forward, transform.forward*10, true, false);
            if (arc.DrawArc(out hitInfo))
            {

            }
        }
	}
}
