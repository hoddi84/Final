using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Type_0,
    Type_A,
    Type_B,
    Type_C
}

public class ProType : MonoBehaviour {

    private const string PLAYER = "Player";

    public Action<GameObject, UnitType, UnitType> onTriggerEntered = null;

    public UnitType unitType;
    public UnitType unitTypeConnecter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER)
        {
            if (onTriggerEntered != null)
            {
                onTriggerEntered(gameObject, unitType, unitTypeConnecter);
            }
        }
    }

}
