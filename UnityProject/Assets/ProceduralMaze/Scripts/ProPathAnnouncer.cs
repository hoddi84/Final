using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProPathAnnouncer : MonoBehaviour {

    private ProPathTrigger pathTrigger = null;
    private int pathCounter = 0;

    public Text txtPathList;

    private void Awake()
    {
        pathTrigger = FindObjectOfType<ProPathTrigger>();
    }

    private void Start()
    {
        PopulatePaths(pathTrigger);
    }

    private void PopulatePaths(ProPathTrigger pathTrigger)
    {
        txtPathList.text = "";

        foreach (GameObject path in pathTrigger.enableForwardPaths)
        {
            print(path.name);
        }

        foreach (GameObject path in pathTrigger.enableForwardPaths)
        {
            if (pathCounter == pathTrigger.rndPathIndex)
            {
                txtPathList.text += path.name + " <---" + "\n";
            }
            else
            {
                txtPathList.text += path.name + "\n";
            }
            pathCounter++;
        }
    }
}
