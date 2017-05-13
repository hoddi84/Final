using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class takes care of locking the doors for us
 * when we click on the lock sprite, as well as chaning the
 * state of the sprite to correspond to the door being locked or unlocked.
 */
public class MazeDoorLock : MonoBehaviour {

    public Sprite spriteLocked;
    public Sprite spriteUnlocked;
    public MazeDoorController doorController;

    private AudioSource lockingSound;

	// Use this for initialization
	void Start () {

        lockingSound = GetComponentInChildren<AudioSource>();
	}

    /*
     * This method is called from our InputManager when we press the
     * lock symbol with our mouse.
     */
    public void ToggleMechanicState()
    {
        if (doorController.canInteract)
        {
            if (doorController.doorIsLocked)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked;
                doorController.doorIsLocked = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteLocked;
                doorController.doorIsLocked = true;
                lockingSound.Play();
            }
        }
    }
}
