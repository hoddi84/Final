//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;

public struct PointerEventArgs
{
    public uint controllerIndex;
    public uint flags;
    public float distance;
    public Transform target;
}

public delegate void PointerEventHandler(object sender, PointerEventArgs e);


public class SteamVR_LaserPointer : MonoBehaviour
{
    public bool active = true;
    public Color color;
    public float thickness = 0.002f;
    public GameObject holder;
    public GameObject pointer;
    bool isActive = false;
    public bool addRigidBody = false;
    public Transform reference;
    public event PointerEventHandler PointerIn;
    public event PointerEventHandler PointerOut;

    Transform previousContact = null;

    /*
     * The following is to disable the laser until the Pad is clicked.
     */
    private bool laserActivated = false;
    private SteamVR_TrackedController controller;

    void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.PadClicked += HandlePadClicked;
        controller.PadUnclicked += HandlePadUnclicked; 
    }

    void OnDisable()
    {
        controller.PadClicked -= HandlePadClicked;
        controller.PadUnclicked -= HandlePadUnclicked;
    }

    void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        laserActivated = true;
    }

    void HandlePadUnclicked(object sender, ClickedEventArgs e)
    {
        laserActivated = false;
    }

	// Use this for initialization
	void Start ()
    {
        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;
		holder.transform.localRotation = Quaternion.identity;

		pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
        pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
		pointer.transform.localRotation = Quaternion.identity;
		BoxCollider collider = pointer.GetComponent<BoxCollider>();
        if (addRigidBody)
        {
            if (collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if(collider)
            {
                Object.Destroy(collider);
            }
        }
        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newMaterial.SetColor("_Color", color);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
	}

    public virtual void OnPointerIn(PointerEventArgs e)
    {
        if (PointerIn != null)
            PointerIn(this, e);
    }

    public virtual void OnPointerOut(PointerEventArgs e)
    {
        if (PointerOut != null)
            PointerOut(this, e);
    }


    // Update is called once per frame
	void Update ()
    {
        /*
         * The following is added to enable the laser pointer if the pad has been clicked,
         * and disable it when the pad is unclicked.
         */

        if (laserActivated)
        {
            pointer.SetActive(true);
        }
        else
        {
            pointer.SetActive(false);
        }

        if (!isActive)
        {
            isActive = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        float dist = 100f;

        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if(previousContact && previousContact != hit.transform)
        {
            PointerEventArgs args = new PointerEventArgs();
            if (controller != null)
            {
                args.controllerIndex = controller.controllerIndex;
            }
            args.distance = 0f;
            args.flags = 0;
            args.target = previousContact;
            OnPointerOut(args);
            previousContact = null;
        }
        if(bHit && previousContact != hit.transform)
        {
            PointerEventArgs argsIn = new PointerEventArgs();
            if (controller != null)
            {
                argsIn.controllerIndex = controller.controllerIndex;
            }
            argsIn.distance = hit.distance;
            argsIn.flags = 0;
            argsIn.target = hit.transform;
            OnPointerIn(argsIn);
            previousContact = hit.transform;
        }
        if(!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if (controller != null && controller.triggerPressed)
        {
            pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, dist);
        }
        else
        {
            pointer.transform.localScale = new Vector3(thickness, thickness, dist);
        }
        pointer.transform.localPosition = new Vector3(0f, 0f, dist/2f);
    }
}
