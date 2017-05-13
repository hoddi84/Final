using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorOpener : MonoBehaviour {

    /*
     * This class allows us to close and open the door, as well as
     * changing the state of the sprite to be corresponding to the 
     * door being open on closed.
     */
    public Sprite doorClosed;
    public Sprite doorOpen;
    public MazeDoorController mazeController;

    public AudioClip doorSlam;

    public int rotateDegrees = 20;
    public float rotateTimeOpen = 5f;
    public float rotateTimeClose = 5f;

    /*
     * This method is called from our InputManager when we click the door symbol
     * with our mouse.
     */
    public void OpenDoor()
    {
        if (!mazeController.doorIsLocked)
        {
            if (mazeController.canInteract)
            {
                mazeController.canInteract = false;
                StartCoroutine(MazeUtility.RotateOverSeconds(null, doorSlam, mazeController, mazeController.doorObject, rotateDegrees, rotateTimeOpen, rotateTimeClose, mazeController.openHandleOutwards));

                /*
                 * When closing the door, the above coroutine takes care of playing a slam sound for us,
                 * when it has finished closing the door. We also change the sprite value here.
                 */
                if (mazeController.openHandleOutwards)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
                    mazeController.openHandleOutwards = false;
                }
                else
                {
                    /*
                     * When opening the door, we open it slowly while playing a creeking sound,
                     * as well as changing the sprite.
                     */
                    gameObject.GetComponentInChildren<AudioSource>().Play();
                    gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                    mazeController.openHandleOutwards = true;
                }
            }
        }
    }
}
