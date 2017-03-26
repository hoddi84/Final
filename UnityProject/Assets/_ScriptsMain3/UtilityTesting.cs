using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityTesting : MonoBehaviour {

    public InputManager manager;

    public GameObject obj;
    public float degrees;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //UtilityManager.RotateObject(obj, 30f);
            print("clicekd");
            StartCoroutine(UtilityManager.rot(obj, degrees));
        }
	}
}
