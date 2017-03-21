using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The purpose of this script is to provide a fadeout and
 * fade in effect for the camera rig camera. If the activeControllers
 * boolean is true than you can control the fade effect with the vive 
 * controllers, else you must press a button. 
 */
public class FadeController : MonoBehaviour {

    private SteamVR_TrackedController controller;
    private GameObject eyes;

    private bool fading = false;
    private bool ready = true;

    private int fadeOutDuration = 3;
    private int fadeInDuration = 20;

    public bool activeControllers = false;

    void Start()
    {
        if (!activeControllers)
        {
            eyes = GameObject.Find("Camera (eye)");
            if (eyes.GetComponent<SteamVR_Fade>() == null)
            {
                eyes.AddComponent<SteamVR_Fade>();
            }
        }
    }

    void Update()
    {
        if (!activeControllers)
        {
            if (Input.GetKeyDown(KeyCode.F) && !fading && ready)
            {
                ready = false;
                print("read");
                StartCoroutine(FadeToBlack());
            }
            else if (Input.GetKeyDown(KeyCode.F) && fading && ready)
            {
                ready = false;
                StartCoroutine(FadeFromBlack());
            }
        }
    }

    void OnEnable()
    {
        if (activeControllers)
        {
            eyes = GameObject.Find("Camera (eye)");
            if (eyes.GetComponent<SteamVR_Fade>() == null)
            {
                eyes.AddComponent<SteamVR_Fade>();
            }
            controller = GetComponent<SteamVR_TrackedController>();
            controller.TriggerClicked += HandleTriggerClicked;
            controller.PadClicked += HandlePadClicked;
        }

    }

    void OnDisable()
    {
        if (activeControllers)
        {
            controller.TriggerClicked -= HandleTriggerClicked;
            controller.PadClicked -= HandlePadClicked;
        }

    }

    void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        if (!fading && ready)
        {
            ready = false;
            StartCoroutine(FadeToBlack());
        }
        else if (fading && ready)
        {
            ready = false;
            StartCoroutine(FadeFromBlack());
        }    
    }

    void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        print("Pad Clicked");
    }

    IEnumerator FadeToBlack()
    {
        print("started");
        SteamVR_Fade.Start(Color.black, fadeOutDuration);
        yield return new WaitForSeconds(fadeOutDuration);
        ready = true;
        fading = true;
        print("ended");
    }

    IEnumerator FadeFromBlack()
    {
        SteamVR_Fade.Start(Color.clear, fadeInDuration);
        yield return new WaitForSeconds(fadeInDuration);
        ready = true;
        fading = false;
    }
}
