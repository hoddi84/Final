using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityManager : MonoBehaviour {

    public static void DisplayMessage(GameObject obj, Text textObject)
    {
        textObject.text = "Name: " + obj.name + "\n" +
                          "Tag: " + obj.tag + "\n";                  
    }
}
