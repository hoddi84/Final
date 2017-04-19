using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeUtility : MonoBehaviour {

    public static void AnnounceState(Text textArea, string message)
    {
        textArea.text = message;
    }
}
