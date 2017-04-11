using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    /*
     * Make a zombie appear at selected position and
     * flicker the lights in the nearest surrounding.
     * 
     * The selected position can only be objects tagged ZombieAppearFloor.
     * 
     * TODO
     * Make it more generic so that it will work correctly, e.g. if the lights were previously
     * turn off, then there is no need to play the turn off sound and no need to have the light
     * turned on after the event.
     */
    public static IEnumerator ScaryCharacterSpawn(GameObject characterToSpawn, Vector3 characterPos, GameObject cameraRig, AudioClip lightOffSound, AudioClip lightAmbienceSound)
    {
        /*
         * Adjust the Spawned object to be facing a certain object, e.g. the VRHelmet.
         */
        Vector3 directionToFace = (cameraRig.transform.position - characterPos);
        directionToFace.y = 0;

        /*
         * Flicker the lights around the spawned character.
         */
        GameObject[] lightObj = GameObject.FindGameObjectsWithTag("ChangeableLight");
        List<GameObject> lightObjUsed = new List<GameObject>();

        float range = 5f;
        float flicker = .1f;
        float firstDelay = 1f;
        float secondDelay = 2f;

        /*
         * Get the closest lights.
         */
        foreach (GameObject obj in lightObj)
        {
            if ((obj.transform.position - characterPos).sqrMagnitude < range)
            {
                lightObjUsed.Add(obj);
            }
        }

        /*
         * Turn off the lights and play a sound.
         */
        foreach (GameObject light in lightObjUsed)
        {
            light.GetComponentInChildren<Light>().intensity = 0;
            light.GetComponentInChildren<AudioSource>().Stop();
            light.GetComponentInChildren<AudioSource>().loop = false;
            light.GetComponentInChildren<AudioSource>().clip = lightOffSound;
            light.GetComponentInChildren<AudioSource>().Play();
        }

        yield return new WaitForSeconds(firstDelay);

        foreach (GameObject light in lightObjUsed)
        {
            light.GetComponentInChildren<Light>().intensity = 1;
        }

        GameObject spawnedCharacter = Instantiate(characterToSpawn, characterPos, Quaternion.LookRotation(directionToFace));

        yield return new WaitForSeconds(flicker);

        foreach (GameObject light in lightObjUsed)
        {
            light.GetComponentInChildren<Light>().intensity = 0;
        }

        Destroy(spawnedCharacter);

        yield return new WaitForSeconds(secondDelay);

        /*
         * Turn on the lights again and play ambience.
         */
        foreach (GameObject light in lightObjUsed)
        {
            light.GetComponentInChildren<Light>().intensity = 1;
            light.GetComponentInChildren<AudioSource>().Stop();
            light.GetComponentInChildren<AudioSource>().loop = true;
            light.GetComponentInChildren<AudioSource>().clip = lightAmbienceSound;
            light.GetComponentInChildren<AudioSource>().Play();
        }

        yield return null;
    }


	/*
     * Hide / Unhide different kinds of entrances.
     */
    public static void HideEntrance(GameObject objToHide, GameObject objToShow, bool hideObject)
    {
        if (hideObject)
        {
            objToHide.SetActive(false);
            objToShow.SetActive(true);
        }
        else
        {
            objToHide.SetActive(true);
            objToShow.SetActive(false);
        }
    }

    public static IEnumerator ZombieScare(GameObject obj, AudioClip clip)
    {
        Animator anim = obj.GetComponentInChildren<Animator>();
        AudioSource audio = obj.GetComponentInChildren<AudioSource>();

        anim.SetBool("ZombieScare", true);
        audio.clip = clip;
        audio.Play();

        yield return null;
    }

    public static IEnumerator CrawlerFramedScare(GameObject obj, AudioClip clip) 
    {
        Animator anim = obj.GetComponentInChildren<Animator>();
        AudioSource audio = obj.GetComponentInChildren<AudioSource>();

        anim.SetBool("CrawlerFrameScare", true);
        audio.clip = clip;
        audio.Play();

        yield return new WaitForSeconds(3.8f);

        anim.SetBool("CrawlerFrameScare", false);

        yield return null;
    }
}
