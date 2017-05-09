using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIVEControllerManager : MonoBehaviour {

    /*
     * Use this to trigger a pulse in both controllers simulatneously.
     */
    public SteamVR_TrackedController controller1;
    public SteamVR_TrackedController controller2;

    public void TriggerContinuousPulseBoth()
    {
        MazeUtility.TriggerContinuousVibration(controller1, 1);
        MazeUtility.TriggerContinuousVibration(controller2, 1);
    }
}
