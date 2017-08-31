using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProNode2 : MonoBehaviour {

    public GameObject player;
    public GameObject content;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetInstanceID() == other.gameObject.GetInstanceID())
        {

        }
    }

    public void SetContentActive(bool condition)
    {
        content.SetActive(condition);
    }
}
