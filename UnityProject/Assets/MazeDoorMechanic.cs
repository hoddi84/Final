using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorMechanic : MonoBehaviour {

    public Sprite spriteLocked;
    public Sprite spriteUnlocked;
    public bool doorLocked = false;
    public MazeDoorController doorController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleMechanicState()
    {
        if (doorLocked)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked;
            doorLocked = false;
            doorController.doorIsLocked = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteLocked;
            doorLocked = true;
            doorController.doorIsLocked = true;
        }
    }
}
