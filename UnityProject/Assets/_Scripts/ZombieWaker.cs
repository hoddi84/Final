using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaker : MonoBehaviour {

    private HeadLookController lookController;
    public ViveController controller;

    public Transform headDown;
    public Transform headFollowRig;

    private AudioSource audio;

    public AudioClip zombieBreathe;
    public AudioClip zombieWakeUp;
    public AudioClip zombieSleep;

    private bool finishedWakeSound = false;
    private bool finishedSleepSound = false;

    public bool usingControllers = false;

    private bool gripped = false;

	// Use this for initialization
	void Start () {

        lookController = GetComponent<HeadLookController>();
        lookController.target = headDown.position;

        audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (usingControllers)
        {
            if (controller.gripped)
            {
                lookController.target = headFollowRig.position;
                if (!finishedWakeSound)
                {
                    StartCoroutine(ZombieWakeUp());
                    finishedWakeSound = true;
                }
            }
            else
            {
                lookController.target = headDown.position;
                if (!finishedSleepSound)
                {
                    StartCoroutine(ZombieSleep());
                    finishedSleepSound = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.T) && !gripped)
        {
            gripped = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && gripped)
        {
            gripped = false;
        }

        if (gripped)
        {
            lookController.target = headFollowRig.position;
            if (!finishedWakeSound)
            {
                StartCoroutine(ZombieWakeUp());
                finishedWakeSound = true;
            }
        }
        else
        {
            lookController.target = headDown.position;
            if (!finishedSleepSound)
            {
                StartCoroutine(ZombieSleep());
                finishedSleepSound = true;
            }
        }
    }

    IEnumerator ZombieWakeUp()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
        audio.clip = zombieWakeUp;
        audio.loop = false;
        audio.Play();
        yield return new WaitUntil(() => !audio.isPlaying);
        audio.clip = zombieBreathe;
        audio.loop = true;
        audio.Play();
        finishedSleepSound = false;
    }

    IEnumerator ZombieSleep()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
        audio.clip = zombieSleep;
        audio.loop = false;
        audio.Play();
        finishedWakeSound = false;
        yield return null;
    }
}
