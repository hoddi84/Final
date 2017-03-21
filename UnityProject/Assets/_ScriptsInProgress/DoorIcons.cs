using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIcons : MonoBehaviour {

    public Sprite locked;
    public Sprite unlocked;

    private GameObject[] doors;
	// Use this for initialization
	void Start () {

        doors = GameObject.FindGameObjectsWithTag("ChangeableDoor");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetUpIcons()
    {
        foreach (GameObject x in doors)
        {
            GameObject icon = new GameObject();
            icon.AddComponent<SpriteRenderer>();
            icon.GetComponent<SpriteRenderer>().sprite = locked;
            icon.transform.parent = x.transform;
        }
    }
}
