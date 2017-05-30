using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public void OnEnterCollider(GameObject obj)
    {
        if (CheckIfRelevant(obj))
        {
            obj.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            print("Changing color on " + obj.name + " to " + obj.GetComponent<MeshRenderer>().material.color);
        }

    }

    private bool CheckIfRelevant(GameObject obj)
    {
        if (obj.GetInstanceID() == gameObject.GetInstanceID())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
