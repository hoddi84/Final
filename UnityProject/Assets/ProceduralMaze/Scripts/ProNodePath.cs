using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProNodePath : MonoBehaviour {

    private ProNode1 node;

    private void Start()
    {
        node = FindObjectOfType<ProNode1>();
        print(node.gameObject.name);
    }
}
