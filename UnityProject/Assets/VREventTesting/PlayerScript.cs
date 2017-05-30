using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public delegate void EnterColliderEventHandler(GameObject obj);

    public event EnterColliderEventHandler EnterCollider;

    private void OnTriggerEnter(Collider other)
    {
        OnEnterCollider(other.gameObject);
    }

    public void OnEnterCollider(GameObject obj)
    {
        if (EnterCollider != null)
        {
            EnterCollider(obj);
        }
    }
}
