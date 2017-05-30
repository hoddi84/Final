using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public void OnEnterCollider(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
