using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utility : MonoBehaviour {

    public static void UpdateSpawnablesText(Text spawnText, int counter, bool enabled)
    {
        if (counter == 0 && !enabled)
        {
            spawnText.text = "H : Current Spawnable (disabled) \n" +
                             "Zombie Appears";
        }
        else if (counter == 0 && enabled)
        {
            spawnText.text = "H : Current Spawnable (enabled) \n" +
                             "Zombie Appears";
        }
        else if (counter == 1 && !enabled)
        {
            spawnText.text = "H : Current Spawnable (disabled) \n" +
                             "Scarecrow Appears";
        }
        else if (counter == 1 && enabled)
        {
            spawnText.text = "H : Current Spawnable (enabled) \n" +
                             "Scarecrow Appears";
        }
    }

    /*
     * Make a zombie appear at selected position and
     * flicker the lights in the nearest surrounding.
     * 
     * The selected position can only be objects tagged ZombieAppearFloor.
     * 
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

        print("Lights: " + lightObj.Length);

        float range = 7f;
        float flicker = .08f;
        float firstDelay = .1f;
        float secondDelay = .1f;

        /*
         * Get the closest lights.
         */
        foreach (GameObject obj in lightObj)
        {
            if ((obj.transform.position - cameraRig.transform.position).sqrMagnitude < range)
            {
                lightObjUsed.Add(obj);
            }
        }

        /*
         * Turn off the lights and play a sound.
         */
        foreach (GameObject light in lightObjUsed)
        {
            /*
             * Only turn off the lights and play a sound if the lights
             * are allready turned on.
             */
            /*
            if (light.GetComponent<SliderValues>().LightsOn() == 1)
            {
                light.GetComponentInChildren<Light>().intensity = 0;
                light.GetComponentInChildren<AudioSource>().Stop();
                light.GetComponentInChildren<AudioSource>().loop = false;
                light.GetComponentInChildren<AudioSource>().clip = lightOffSound;
                light.GetComponentInChildren<AudioSource>().Play();

                yield return new WaitForSeconds(firstDelay);
            }
            */
            if (light.GetComponentInChildren<Light>().intensity > 0)
            {
                Light[] l = light.GetComponentsInChildren<Light>();
                foreach (Light x in l)
                {
                    x.intensity = 0;
                }
                light.GetComponentInChildren<AudioSource>().Stop();
                light.GetComponentInChildren<AudioSource>().loop = false;
                light.GetComponentInChildren<AudioSource>().clip = lightOffSound;
                light.GetComponentInChildren<AudioSource>().Play();
            }
        }

        yield return new WaitForSeconds(flicker);

        GameObject spawnedCharacter = Instantiate(characterToSpawn, characterPos, Quaternion.LookRotation(directionToFace, Vector3.up));

        /*
         * Turn on the lights again, with a character spawned. 
         */
        foreach (GameObject light in lightObjUsed)
        {
            // light.GetComponentInChildren<Light>().intensity = 1;
            Light[] l = light.GetComponentsInChildren<Light>();
            foreach (Light x in l)
            {
                x.intensity = 1;
            }
        }

        yield return new WaitForSeconds(flicker);

        /*
         * Turn off the lights again, with character gone.
         */
        foreach (GameObject light in lightObjUsed)
        {
            // light.GetComponentInChildren<Light>().intensity = 0;
            Light[] l = light.GetComponentsInChildren<Light>();
            foreach (Light x in l)
            {
                x.intensity = 0;
            }
        }

        yield return new WaitForSeconds(flicker);

        /*
         * Turn on the lights again.
         */
        foreach (GameObject light in lightObjUsed)
        {
            // light.GetComponentInChildren<Light>().intensity = 1;
            Light[] l = light.GetComponentsInChildren<Light>();
            foreach (Light x in l)
            {
                x.intensity = 1;
            }
        }

        yield return new WaitForSeconds(flicker);

        /*
         * Turn off the lights again, with character gone.
         */
        foreach (GameObject light in lightObjUsed)
        {
            // light.GetComponentInChildren<Light>().intensity = 0;
            Light[] l = light.GetComponentsInChildren<Light>();
            foreach (Light x in l)
            {
                x.intensity = 0;
            }
        }

        yield return new WaitForSeconds(flicker);

        /*
         * Turn on the lights again and play ambience.
         * Event is now finished, return the lights to their original setting.
         */
        Destroy(spawnedCharacter);

        foreach (GameObject light in lightObjUsed)
        {
            /*
             * Check whether the lights were previously turned on before
             * the event started.
             */
            /*
           if (light.GetComponent<SliderValues>().LightsOn() == 1)
           {
               light.GetComponentInChildren<Light>().intensity = 1;
               light.GetComponentInChildren<AudioSource>().Stop();
               light.GetComponentInChildren<AudioSource>().loop = true;
               light.GetComponentInChildren<AudioSource>().clip = lightAmbienceSound;
               light.GetComponentInChildren<AudioSource>().Play();
           }
           */
            Light[] l = light.GetComponentsInChildren<Light>();
            foreach (Light x in l)
            {
                x.intensity = 1;
            }
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
