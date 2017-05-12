using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoorOpener : MonoBehaviour {

    public Sprite doorClosed;
    public Sprite doorOpen;
    public MazeDoorController mazeController;

    public AudioClip doorSlam;

    public int rotateDegrees = 20;
    public float rotateTimeOpen = 5f;
    public float rotateTimeClose = 5f;

    public void OpenDoor()
    {
        if (!mazeController.doorIsLocked)
        {
            if (mazeController.canInteract)
            {
                mazeController.canInteract = false;
                StartCoroutine(MazeUtility.RotateOverSeconds(null, doorSlam, mazeController, mazeController.doorObject, rotateDegrees, rotateTimeOpen, rotateTimeClose, mazeController.openHandleOutwards));
                if (mazeController.openHandleOutwards)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
                    mazeController.openHandleOutwards = false;
                }
                else
                {
                    gameObject.GetComponentInChildren<AudioSource>().Play();
                    gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                    mazeController.openHandleOutwards = true;
                }
            }
        }
    }
}
