using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


/*
 * Makes it possible to move specific objects in the scene
 * through the map view, objects must be of tag "MovableObject"
 */
public class MainController : MonoBehaviour {

    private Transform movableObject;
    private GameObject changeableObject;

    // If you have selected a movable object.
    private bool movableObjectControlled = false;
    // If you have selected a movable message.
    private bool movableMessageControlled = false;

    public Camera mapCamera;
    public Text optionText;
    public GameObject sliderObject;

    private Slider SliderScript;

    private string activatedType;

    private bool mouseLeftPressedDown = false;
    private bool mouseRightPressedDown = false;

    void OnEnable()
    {
        EventManager.MouseDownLeft += MouseDownLeftHandler;
        EventManager.MouseUpLeft += MouseUpLeftHandler;
        EventManager.MouseDownRight += MouseDownRightHandler;
        EventManager.MouseUpRight += MouseUpRightHandler;
    }

    void OnDisable()
    {
        EventManager.MouseDownLeft -= MouseDownLeftHandler;
        EventManager.MouseUpLeft -= MouseUpLeftHandler;
        EventManager.MouseDownRight -= MouseDownRightHandler;
        EventManager.MouseUpRight -= MouseUpRightHandler;
    }

    void MouseDownRightHandler()
    {
        mouseRightPressedDown = true;
    }

    void MouseUpRightHandler()
    {
        mouseRightPressedDown = false;
    }

    void MouseDownLeftHandler()
    {
        mouseLeftPressedDown = true;
    }

    void MouseUpLeftHandler()
    {
        mouseLeftPressedDown = false;
    }

    void Start()
    {
        /*
         * Disable visible option controls in the beginning.
         */
        sliderObject.SetActive(false);

        SliderScript = sliderObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update () {

        /*
         * Left mouse button, move objects.
         */
        if (mouseLeftPressedDown)
        {
            Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10)) {
                if (!movableObjectControlled)
                {
                    if (hit.transform.tag == "MovableObject")
                    {
                        movableObject = hit.transform;
                        movableObjectControlled = true;
                    }
                    else if (hit.transform.tag == "MovableMessage")
                    {
                        movableObject = hit.transform;
                        movableMessageControlled = true;
                    }
                }
            }

            // If true, selected object will completely follow mouse cursor.
            if (movableObjectControlled)
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = 15f;
                v3 = mapCamera.ScreenToWorldPoint(v3);

                movableObject.position = new Vector3(v3.x, movableObject.position.y, v3.z);
            }

            // If true, can move the message controller around the x-axis.
            if (movableMessageControlled)
            {
                Vector3 v3 = Input.mousePosition;
                v3.z = 15f;
                v3 = mapCamera.ScreenToWorldPoint(v3);

                movableObject.position = new Vector3(v3.x, movableObject.position.y, movableObject.position.z);
            }
        }

        if (!mouseLeftPressedDown)
        {
            movableObjectControlled = false;
            movableMessageControlled = false;
            movableObject = null;
        }

        /*
         * Right mouse button, display options for a selected object.
         */
        if (mouseRightPressedDown)
        {
            Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                /*
                 * What kind of object did the user hit. 
                 */
                if (hit.transform.tag == "ChangeableObject")
                {
                    changeableObject = hit.transform.gameObject;
                    activatedType = ControllableTypes.StaticObject.ToString();
                }
                else if (hit.transform.tag == "ChangeableLight")
                {
                    changeableObject = hit.transform.gameObject;
                    activatedType = ControllableTypes.Light.ToString();

                }
                else if (hit.transform.tag == "ChangeableDoor")
                {
                    changeableObject = hit.transform.gameObject;
                    activatedType = ControllableTypes.Door.ToString();
                }
            }
        }

        ActivateOptions(changeableObject);
	}

    /*
     * Displays the selected objects options.
     * Remember the slider's value from previous selections through SliderValues script.
     */
    void ActivateOptions(GameObject selectedObj)
    {
        if (selectedObj != null) {
            if (activatedType == ControllableTypes.StaticObject.ToString())
            {
                ChangeObject(selectedObj);
                sliderObject.SetActive(false);
            }
            else if (activatedType == ControllableTypes.Light.ToString())
            {
                ChangeLight(selectedObj);
                SliderScript.value = selectedObj.GetComponent<SliderValues>().GetSliderValue();
                sliderObject.SetActive(true);
            }
            else if (activatedType == ControllableTypes.Door.ToString())
            {
                ChangeDoor(selectedObj);
                SliderScript.value = selectedObj.GetComponent<SliderValues>().GetSliderValue();
                sliderObject.SetActive(true);
            }
        }
    }

    /*
     * Available options for a light object.
     * 
     * We must also change the sliders position depending
     * on wether the light is turned off or on.
     */
    public void ChangeLight(GameObject obj)
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
                obj.GetComponent<SliderValues>().SetSliderValue(0f);
                SliderScript.value = 0;
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
                obj.GetComponent<SliderValues>().SetSliderValue(1f);
                SliderScript.value = 1;
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
                obj.GetComponent<SliderValues>().SetSliderValue(0f);
                SliderScript.value = 0;
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
                obj.GetComponent<SliderValues>().SetSliderValue(1f);
                SliderScript.value = 1;
            }
        }

    }

    /*
     * For objects which properties can be controlled by the slider, 
     * e.g. the intensity of a light or a door. Each object that can be manipulated 
     * with the slider must have the SliderValues script, so that the object can 
     * remember it's changing values.
     */
    public void ChangeLightSlider(float newIntensity)
    {
        if (changeableObject != null)
        {
            if (changeableObject.tag == "ChangeableLight")
            {
                changeableObject.GetComponent<Light>().intensity = newIntensity;
                changeableObject.GetComponent<SliderValues>().SetSliderValue(newIntensity);
            }
            else if (changeableObject.tag == "ChangeableDoor")
            {
                changeableObject.GetComponent<Transform>().localEulerAngles = new Vector3(0, 270 - newIntensity*100, 0);
                changeableObject.GetComponent<SliderValues>().SetSliderValue(newIntensity);
            }   
        }
    }

    /*
     * Available options for a static object.
     * 
     * Hides an object by changing it's layer to a 
     * layer masked by the camera, i.e. the UserHidden layer
     * which is on layer 8.
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
