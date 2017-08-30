using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProPathTrigger : MonoBehaviour {

    public GameObject player;
    public GameObject[] enableForwardPaths;
    public GameObject disablePreviousPath;

    public int rndPathIndex;

    private void Start()
    {
        foreach (GameObject path in enableForwardPaths)
        {
            path.SetActive(false);
        }

        rndPathIndex = Random.Range(0, enableForwardPaths.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetInstanceID() == other.gameObject.GetInstanceID())
        {
            EnablePath(rndPathIndex);

            DisablePath();
        }
    }

    private void EnablePath(int pathIndex)
    {
        foreach (GameObject path in enableForwardPaths)
        {
            path.SetActive(false);
        }
        enableForwardPaths[pathIndex].SetActive(true);
    }

    private void DisablePath()
    {
        if (disablePreviousPath != null)
        {
            disablePreviousPath.SetActive(false);
        }
    }
}
