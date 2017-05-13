using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLightController : MonoBehaviour {

    public Sprite lightsOnSprite;
    public Sprite lightsOffSprite;

    public AudioClip lightSwitchSound;
    public AudioClip lightAmbienceSound;

    public SpriteRenderer spriteRenderer;

    private List<float> lightsIntensity = new List<float>();

	// Use this for initialization
	void Start () {

        Light[] lights = GetComponentsInChildren<Light>();

        foreach (Light light in lights)
        {
            float intensity = light.intensity;
            lightsIntensity.Add(intensity);
        }
	}

    /*
     * Call this method to toggle the lights, i.e. if the lights are turned on
     * we turned them off, and vice versa. As well as changing the light bulb sprite
     * to it's corresponding value.
     */
    public void ToggleLights()
    {
        if (AreLightsTurnedOn())
        {
            TurnOffAllLights();
            PlayLightSwitch();
            spriteRenderer.sprite = lightsOffSprite;
        }
        else
        {
            TurnOnAllLights();
            StartCoroutine(PlayLightAmbience());
            spriteRenderer.sprite = lightsOnSprite;
        }
    }

    /*
     * A check to see whether the lights are turned on or not.
     */
    bool AreLightsTurnedOn()
    {
        Light[] lights = GetComponentsInChildren<Light>();

        foreach (Light light in lights)
        {
            if (light.intensity == 0)
            {
                return false;
            }
        }
        return true;
    }

    /*
     * Turn off the lights.
     */
    void TurnOffAllLights()
    {
        Light[] lights = GetComponentsInChildren<Light>();

        foreach (Light light in lights)
        {
            light.intensity = 0;
        }
    }

    /*
     * Turn on the lights, reverting to previous light settings.
     * We get the previous light settings for the allLights list.
     */
    void TurnOnAllLights()
    {
        Light[] lights = GetComponentsInChildren<Light>();

        for (int i = 0; i < lightsIntensity.Count; i++)
        {
            /*
             * We know lights and lightsIntensity are of equal size.
             */
            lights[i].intensity = lightsIntensity[i];
        }
    }

    /*
     * When we turn on the lights, we will play the light switch sound
     * and after that we will continue to play the light ambience sound.
     */
    IEnumerator PlayLightAmbience()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = lightSwitchSound;
        audio.loop = false;
        audio.Play();

        yield return new WaitUntil(() => !audio.isPlaying);

        audio.clip = lightAmbienceSound;
        audio.loop = true;
        audio.Play();

        yield return null;
    }

    /*
     * When we are turning off the lights, we will play the light swtich sound.
     */
    void PlayLightSwitch()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (audio.isPlaying)
        {
            audio.Stop();
        }
        audio.clip = lightSwitchSound;
        audio.loop = false;
        audio.Play();
    }
}
