using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvents : MonoBehaviour {

    private bool rayHit;

    void OnEnable()
    {
        ControlManager.MouseLeftRaycastHit += RayCastLeft;
    }

    void OnDisable()
    {
        ControlManager.MouseLeftRaycastHit -= RayCastLeft;
    }

    void RayCastLeft()
    {
        rayHit = true;
        print("hit");
    }
}
