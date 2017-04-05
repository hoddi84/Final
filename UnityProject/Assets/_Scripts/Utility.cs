using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

	/*
     * Hide / Unhide different kinds of entrances.
     */
    public static void HideEntrance(GameObject objToHide, GameObject objToShow, bool hideObject)
    {
        if (hideObject)
        {
            objToHide.SetActive(false);
            objToShow.SetActive(true);
        }
        else
        {
            objToHide.SetActive(true);
            objToShow.SetActive(false);
        }
    }
}
