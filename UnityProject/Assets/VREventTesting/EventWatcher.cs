using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventWatcher : MonoBehaviour {

    private CubeScript[] cubeScripts;
    private PlayerScript playerScript;

    private void Awake()
    {
        cubeScripts = FindObjectsOfType<CubeScript>();
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void OnEnable()
    {
        SubscribeAllListeners();
    }

    private void OnDisable()
    {
        DesubscribeAllListeners();
    }

    private void SubscribeAllListeners()
    {
        foreach (CubeScript x in cubeScripts)
        {
            playerScript.EnterCollider += x.OnEnterCollider;
        }
    }

    private void DesubscribeAllListeners()
    {
        foreach (CubeScript x in cubeScripts)
        {
            playerScript.EnterCollider -= x.OnEnterCollider;
        }
    }
}
