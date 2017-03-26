using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManager : MonoBehaviour {

    public static void RotateObject(GameObject obj, float degrees)
    {
        obj.transform.Rotate(new Vector3(0, 1, 0), 30f);
        print("rotated");
    }

    public static IEnumerator rot(GameObject obj, float degrees)
    {
        obj.transform.Rotate(new Vector3(0, 1, 0), degrees);
        print("rotated");
        yield return null;
    }
}
