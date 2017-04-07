using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

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
