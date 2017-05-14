using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLightFlickerController : MonoBehaviour {

    public GameObject flickerRotator;
    public AudioClip flickerSound;
    public MazeLightController lightController;

    private bool flickerIsUp = true;
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E))
        {
            FlickerSwitchToggle();
        }
	}

    /*
     * Toggle the lights with the light switch.
     */
    public void FlickerSwitchToggle()
    {
        if (flickerIsUp)
        {
            lightController.ToggleLights();
            flickerRotator.transform.Rotate(new Vector3(0, 0, -90));
            PlayFlickerSound();
            flickerIsUp = false;
        }
        else
        {
            lightController.ToggleLights();
            flickerRotator.transform.Rotate(new Vector3(0, 0, 90));
            PlayFlickerSound();
            flickerIsUp = true;
        }
    }

    void PlayFlickerSound()
    {
        AudioSource audio = GetComponentInChildren<AudioSource>();

        audio.clip = flickerSound;
        audio.loop = false;
        audio.Play();
    }
}
