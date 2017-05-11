using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeUtility : MonoBehaviour {

    /*
     * Write the current state.
     */
    public static void AnnounceState(Text textArea, string message)
    {
        textArea.text = message;
    }

    /*
     * Move an object to a new position over a specified amount of time.
     */
    public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, bool onElevator, GameObject rig, bool useHaptics, VIVEControllerManager controllerManager)
    {
        /*
         * If we are moving on an elevator, we must move the camera rig as well.
         */
        if (onElevator)
        {
            rig.transform.parent = objectToMove.transform;
        }

        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {   
            /*
             * If true, haptics will be enabled while the object is moving. 
             */
            if (useHaptics)
            {
                controllerManager.TriggerContinuousPulseBoth();
            }
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;

        /*
         * Once we finish moving we change the parent of rig to previous, which is null.
         */
        rig.transform.parent = null;
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
         * Here we update the rotation on joined states/places, so
         * that when you advance in the environment i.e. a open door will
         * stay open.
         */
        controller.UpdateDoorRotation(objectToMove);

        /*
         * Enable the door to be interacted with again. 
         */
        controller.canInteract = true;
    }

    /*
     * Trigger the VIVE controller haptic pulse over a period of time.
     */
    public static IEnumerator TriggerVibration(SteamVR_TrackedController controller, float vibrationStrength, float vibrationLength)
    {
        for (float i = 0; i < vibrationLength; i += Time.deltaTime)
        {
            SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, vibrationStrength));
            yield return null;
        }    
    }

    /*
     * Trigger a continuous haptic pulse. Strength equal to 1 is the strongest haptic pulse.
     */
    public static void TriggerContinuousVibration(SteamVR_TrackedController controller, float vibrationStrength)
    {
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, vibrationStrength));
    }

    /*
     * Plays an audio clip from the maze door controller.
     */
    public static void PlaySound(MazeDoorController controller, AudioClip clip)
    {
        AudioSource audio = controller.GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = clip;
        audio.loop = false;
        audio.Play();
    }

    /*
     * Plays an audio tune when we interact with object capable of playing audio, i.e. with
     * a tag == MusicPlayer.
     */
     public static IEnumerator PlayMusic(AudioClip startSound, AudioClip trackSound, GameObject obj)
    {
        AudioSource audio = obj.GetComponent<AudioSource>();

        /*
         * Play the start sound, e.g. needle touching the vinyl.
         * Stop the music first, if  any playing and wait a bit before
         * restarting again.
         */
        audio.Stop();

        yield return new WaitForSeconds(.2f);

        audio.loop = false;
        audio.clip = startSound;
        audio.Play();

        yield return new WaitUntil(() => !audio.isPlaying);

        /*
         * Now we play the music track.
         */
        audio.loop = true;
        audio.clip = trackSound;
        audio.Play();

        yield return new WaitUntil(() => !audio.isPlaying);

        audio = null;

        yield return null;
    }
}

