using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaker : MonoBehaviour {

    private HeadLookController lookController;
    public Transform zombieHeadDown;
    public float degreeLookUp = 80;
    public float rotationSpeed = 10f;
    private float rotationTotal = 0f;

    private bool startLookingUp = false;
    private bool startLookingDown = false;
    private bool moveDown = false;

    private Quaternion rotationOriginal;

	// Use this for initialization
	void Start () {

        lookController = GetComponent<HeadLookController>();
        lookController.enabled = false;

        rotationOriginal = zombieHeadDown.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) && !moveDown)
        {
            moveDown = true;
            startLookingUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.R) && moveDown)
        {
            moveDown = false;
            startLookingDown = true;
        }

        if (startLookingUp)
        {
            LookUp();
        }

        if (startLookingDown)
        {
            LookDown();
        }
        
	}

    void LookUp()
    {
        rotationTotal += Time.deltaTime * rotationSpeed;
        zombieHeadDown.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
        if (rotationTotal > degreeLookUp)
        {
            startLookingUp = false;
            rotationTotal = 0f;
            lookController.enabled = true;
        }
    }

    void LookDown()
    {
        lookController.effect = 0f;
        lookController.enabled = false;
        rotationTotal += Time.deltaTime * rotationSpeed;
        zombieHeadDown.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotationSpeed);
        if (rotationTotal > 100)
        {
            startLookingDown = false;
            rotationTotal = 0f;
        }
    }
}
