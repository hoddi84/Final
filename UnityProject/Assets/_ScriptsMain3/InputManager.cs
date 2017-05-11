using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public bool raycastHitRight;
    public bool raycastHitLeft;
    public bool mouseDownRight;
    public bool mouseDownLeft;

    public Camera mapCamera;

    private GameObject selectedObject;

    [Header("Sounds")]
    public AudioClip lightSwitch;
    public AudioClip lightAmbience;

    [Header("Spawnables Settings")]
    public GameObject[] characterSpawn;
    public GameObject objToFace;
    public Text spawnablesText;

    private int characterCounter = 0;
    private bool characterSpawnEnabled = false;

    void OnEnable()
    {
        InputHandler.MouseLeftRaycastHit += RaycastLeft;
        InputHandler.MouseRightRaycastHit += RaycastRight;

        InputHandler.MouseDownRight += MouseDownRight;
        InputHandler.MouseDownLeft += MouseDownLeft;

        InputHandler.MouseUpRight += MouseUpRight;
        InputHandler.MouseUpLeft += MouseUpLeft;
    }

    void OnDisable()
    {
        InputHandler.MouseLeftRaycastHit -= RaycastLeft;
        InputHandler.MouseRightRaycastHit -= RaycastRight;

        InputHandler.MouseDownRight -= MouseDownRight;
        InputHandler.MouseDownLeft -= MouseDownLeft;

        InputHandler.MouseUpRight -= MouseUpRight;
        InputHandler.MouseUpLeft -= MouseUpLeft;
    }

    /*
     * If we hit a collider with the left mouse button
     * this is called. The object's collider we hit will
     * be our selectedObject.
     */
    void RaycastLeft(GameObject obj, Ray ray)
    {
        raycastHitLeft = true;
        selectedObject = obj;

        if (obj.tag == "DoorLock")
        {
            obj.GetComponent<MazeDoorMechanic>().ToggleMechanicState();
        }
        else if (obj.tag == "Toggleable")
        {
            obj.GetComponent<GenericObjectToggler>().Toggle();
        }
        else if (obj.tag == "ElevatorTrigger")
        {
            obj.GetComponent<ElevatorMechanics>().ActivateElevator();
        }
        else if (obj.tag == "ZombieAppearFloor" && characterSpawnEnabled)
        {
            StartCoroutine(Utility.ScaryCharacterSpawn(characterSpawn[characterCounter], new Vector3(ray.origin.x, characterSpawn[characterCounter].transform.localPosition.y, ray.origin.z), objToFace, lightSwitch, lightAmbience));
            Utility.UpdateSpawnablesText(spawnablesText, characterCounter, false);
            characterSpawnEnabled = false;
        }
    }

    void RaycastRight(GameObject obj, Ray ray)
    {
        raycastHitRight = true;
    }

    void MouseDownRight()
    {
        mouseDownRight = true;
    }

    void MouseDownLeft()
    {
        mouseDownLeft = true;
    }

    void MouseUpLeft()
    {
        mouseDownLeft = false;
        raycastHitLeft = false;
    }

    void MouseUpRight()
    {
        mouseDownRight = false;
        raycastHitRight = false;
    }

    void Update()
    {
        /*
         * Used for navigating the spawnables array.
         */
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!characterSpawnEnabled)
            {
                characterSpawnEnabled = true;
            }
            else
            {
                characterCounter++;
                if (characterCounter == characterSpawn.Length)
                {
                    characterCounter = 0;
                }
            }
            Utility.UpdateSpawnablesText(spawnablesText, characterCounter, true);
        }

        /*
         * We hit a collider with the left mouse button. The
         * object we hit is now our selectedObject.
         */
        if (raycastHitLeft)
        {
            if (selectedObject != null)
            {
                if (selectedObject.tag == "Player")
                {
                    Vector3 v3 = Input.mousePosition;
                    v3.z = 15f;
                    v3 = mapCamera.ScreenToWorldPoint(v3);

                    selectedObject.transform.position = new Vector3(v3.x, selectedObject.transform.position.y, v3.z);
                }
            }
        }
        else
        {
            selectedObject = null;
        }
    }
}
