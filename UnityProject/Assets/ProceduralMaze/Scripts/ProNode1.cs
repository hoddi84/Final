using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProNode1 : MonoBehaviour {

    public GameObject player;
    public GameObject content;

    private ProNode2[] connectedNodes;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetInstanceID() == other.gameObject.GetInstanceID())
        {
            ActivateNextPath();
        }
    }

    void ActivateNextPath()
    {
        connectedNodes = FindObjectsOfType<ProNode2>();

        foreach (ProNode2 node in connectedNodes)
        {
            node.SetContentActive(false);
        }

        int rndPathIndex = Random.Range(0, connectedNodes.Length);

        connectedNodes[rndPathIndex].SetContentActive(true);
    }
}
