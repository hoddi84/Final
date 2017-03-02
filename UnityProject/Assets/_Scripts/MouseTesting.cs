using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


/*
 * Makes it possible to move specific objects in the scene
 * through the map view, objects must be of tag "MovableObject"
 */
public class MouseTesting : MonoBehaviour {

    private Transform movableObject;
    private GameObject changeableObject;

    private bool movableObjectCanMove = false;
    private bool movableObjectControlled = false;

    public Camera cam;
    public Text optionText;
    public GameObject sliderLight;

    private Slider LightSlider;

    private string activatedType;

    private Vector3 originalDoorRotation;

    enum TypeNames
    {
        StaticObject,
        Light,
        Door
    };

	void Start () {

        /*
         * Disable visible option controls in the beginning.
         */
        sliderLight.SetActive(false);

        LightSlider = sliderLight.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        /*
         * Left mouse button, move objects.
         */
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10)) {
                if (hit.transform.tag == "MovableObject" && !movableObjectControlled)
                {
                    movableObject = hit.transform;
                    movableObjectCanMove = true;
                    movableObjectControlled = true;
                }
            }

            if (movableObjectCanMove)
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = 15f;
                v3 = cam.ScreenToWorldPoint(v3);

                movableObject.transform.position = new Vector3(v3.x, movableObject.transform.position.y, v3.z);
            }
        } 

        if (Input.GetMouseButtonUp(0))
        {
            movableObjectCanMove = false;
            movableObjectControlled = false;
            movableObject = null;
        }

        /*
         * Right mouse button, display options for a selected object.
         */
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                /*
                 * What kind of object did the user hit. 
                 */
                if (hit.transform.tag == "ChangeableObject")
                {
                    changeableObject = hit.transform.gameObject;
                    activatedType = TypeNames.StaticObject.ToString();
                }
                else if (hit.transform.tag == "ChangeableLight")
                {
                    changeableObject = hit.transform.gameObject;
                    activatedType = TypeNames.Light.ToString();

                }
                else if (hit.transform.tag == "ChangeableDoor")
                {
                    changeableObject = hit.transform.gameObject;
                    originalDoorRotation = hit.transform.localEulerAngles;

                    print(originalDoorRotation);

                    activatedType = TypeNames.Door.ToString();
                }
            }
        }

        ActivateOptions(changeableObject);
	}

    /*
     * Displays the selected objects options.
     */
    void ActivateOptions(GameObject selectedObj)
    {
        if (selectedObj != null) {
            if (activatedType == TypeNames.StaticObject.ToString())
            {
                ChangeObject(selectedObj);
                sliderLight.SetActive(false);
            }
            else if (activatedType == TypeNames.Light.ToString())
            {
                ChangeLight(selectedObj);
                sliderLight.SetActive(true);
            }
            else if (activatedType == TypeNames.Door.ToString())
            {
                ChangeDoor(selectedObj);
                sliderLight.SetActive(true);
            }
        }
    }

    /*
     * Available options for a light object.
     * 
     * We must also change the sliders position depending
     * on wether the light is turned off or on.
     */
    void ChangeLight(GameObject obj)
    {
        bool lightOn;

        if (obj.GetComponent<Light>().intensity > 0)
        {
            lightOn = true;
        }
        else
        {
            lightOn = false;
        }

        if (lightOn)
        {
            optionText.text = "Actions: \n" +
                              "E: Turn OFF light \n" +
                              "Adjust intensity: ";

            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.GetComponent<Light>().intensity = 0;
                LightSlider.value = 0;
            }
        }
        else
        {
            optionText.text = "Actions: \n" +
                              "E: Turn ON light \n" +
                              "Adjust intensity: ";

            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.GetComponent<Light>().intensity = 1;
                LightSlider.value = 1;
            }
        }
        
    }

    /*
     * Available options for a door object.
     * 
     * We must also change the sliders position depending
     * on wether the door is open or not.
     */
    void ChangeDoor(GameObject obj)
    {
        bool doorOpen;

        if (obj.GetComponent<Transform>().localEulerAngles.y < 270)
        {
            doorOpen = true;
        }
        else
        {
            doorOpen = false;
        }

        if (doorOpen)
        {
            optionText.text = "Actions: \n" +
                              "E: CLOSE door \n" +
                              "Adjust door: ";

            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.GetComponent<Transform>().localEulerAngles = new Vector3(0, 270, 0);
                LightSlider.value = 0;
            }
        }
        else
        {
            optionText.text = "Actions: \n" +
                              "E: OPEN door \n" +
                              "Adjust door: ";

            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.GetComponent<Transform>().localEulerAngles = new Vector3(0, 170, 0);
                LightSlider.value = 1;
            }
        }

    }

    /*
     * Slider for changing the intensity of a light.
     */
    public void ChangeLightSlider(float newIntensity)
    {
        if (changeableObject != null)
        {
            if (changeableObject.tag == "ChangeableLight")
            {
                changeableObject.GetComponent<Light>().intensity = newIntensity;
            }
            else if (changeableObject.tag == "ChangeableDoor")
            {
                changeableObject.GetComponent<Transform>().localEulerAngles = new Vector3(0, 270 - newIntensity*100, 0);
            }   
        }
    }

    /*
     * Available options for a static object.
     * 
     * Hides an object by changing it's layer to a 
     * layer masked by the camera.
     */
    void ChangeObject(GameObject obj)
    {
        bool objectVisible = true;

        if (obj.layer == 0)
        {
            optionText.text = "Actions: \n" +
                              "E: Hide object";

            objectVisible = true;
        }
        else if (obj.layer == 8)
        {
            optionText.text = "Actions: \n" +
                              "E: Show object";

            objectVisible = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && objectVisible)
        {
            obj.layer = 8;  
        }
        else if (Input.GetKeyDown(KeyCode.E) && !objectVisible)
        {
            obj.layer = 0;
        }
    }
}
