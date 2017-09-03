using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    TypeA,
    TypeB,
    TypeC,
    TypeD,
    TypeF
}

public class ProType : MonoBehaviour {

    private const string PLAYER = "Player";

    public Action<GameObject> onTriggerEntered = null;

    public UnitType unitType;
    public UnitType unitTypeConnecter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER)
        {
            if (onTriggerEntered != null)
            {
                onTriggerEntered(gameObject);
            }
        }
    }

}
