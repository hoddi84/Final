using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeUtility : MonoBehaviour {

    public static void AnnounceState(Text textArea, string message)
    {
        textArea.text = message;
    }

    public static void AnnounceBranch(Text textArea, string currentState, GameObject[] branches, int branchCounter)
    {
        switch (currentState)
        {
            case "Place1":
                textArea.text = "Branch Toggle (E) \n" + branches[branchCounter].name;
                foreach (GameObject obj in branches)
                {
                    if (obj.name == branches[branchCounter].name)
                    {
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                }
                break;
            default:
                textArea.text = "No branch possible";
                break;
        }
    }

    public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    /*
     * Rotate an door a certain amount of degrees over a specific time, depenging on whether the door
     * was previously open or closed. Plays a handle sound when the door is being opened and plays a closing 
     * sound when the door is closed.
     */
    public static IEnumerator RotateOverSeconds(AudioClip handle, AudioClip close, MazeDoorController controller, GameObject objectToMove, float rotation, float openTime, float closeTime, bool openHandleOutwards)
    {
        AudioSource audio = controller.gameObject.GetComponent<AudioSource>();

        float elapsedTime = 0;
        float seconds;
        Vector3 startingPos = objectToMove.transform.localEulerAngles;
        Vector3 endPos = objectToMove.transform.localEulerAngles;

        if (openHandleOutwards)
        {
            endPos.y += rotation;
        }
        else
        {
            endPos.y -= rotation;
        }

        /*
         * If the door is closed before we start to move it,
         * then play the handle sound.
         */
        if (!controller.DoorOpen())
        {
            audio.clip = handle;
            audio.Play();
        }

        /*
         * We want to be able to have a different opening/closing time.
         * If the door is closed we use the openTime but if the door is
         * open we use the closeTime.
         */
        if (!controller.DoorOpen())
        {
            seconds = openTime;
        }
        else
        {
            seconds = closeTime;
        }

        while (elapsedTime < seconds)
        {
            objectToMove.transform.localEulerAngles = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.localEulerAngles = endPos;

        /*
         * If the door is closed after we have moved it, 
         * we want to play the door close sound.
         */
        if (!controller.DoorOpen())
        {
            audio.clip = close;
            audio.Play();
        }

        /*
         * Enable the door to be interacted with again. 
         */
        controller.canInteract = true;
    }
}
