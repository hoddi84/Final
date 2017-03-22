using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {

    private bool canPickUp;
    private bool holding;

    public bool gripped = false;

    private GameObject objBeingHeld;

    private SteamVR_TrackedController controller;
 
    void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.TriggerUnclicked += HandleTriggerUnclicked;
        controller.Gripped += HandleGripped;
        controller.Ungripped += HandleUnGripped;
    }

    void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
        controller.TriggerUnclicked -= HandleTriggerUnclicked;
        controller.Gripped -= HandleGripped;
        controller.Ungripped -= HandleUnGripped;
    }

    void Update()
    {
        if (holding)
        {
            if (objBeingHeld != null)
            {
                objBeingHeld.transform.parent = transform;
                //objBeingHeld.transform.localRotation = Quaternion.identity;
                objBeingHeld.GetComponent<Rigidbody>().isKinematic = true;
                objBeingHeld.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        else
        {
            if (objBeingHeld != null)
            {
                objBeingHeld.transform.parent = null;
                objBeingHeld.GetComponent<Rigidbody>().isKinematic = false;
                objBeingHeld.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    void HandleGripped(object sender, ClickedEventArgs e)
    {
        gripped = true;
    }

    void HandleUnGripped(object sender, ClickedEventArgs e)
    {
        gripped = false;
    }

    void HandleTriggerClicked(object sender, ClickedEventArgs e) 
    {
        canPickUp = true;
    }

    void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        canPickUp = false;
        holding = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickable" && canPickUp)
        {
            objBeingHeld = other.gameObject;
            holding = true;
        }
    }
}
