using System;
using UnityEngine;

public enum TestUnit
{
    NULL,
    TypeA,
    TypeB,
    TypeC,
    TypeD,
    TypeE,
    TypeE1,
    TypeE2
}

public class TestTrigger : MonoBehaviour {

    private const string PLAYER = "Player";

    public Action<TestTrigger> onTriggerEntered = null;

    public TestUnit fromType;
    public TestUnit isType;
    public TestUnit toType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER)
        {
            if (onTriggerEntered != null)
            {
                onTriggerEntered(this);
            }
        }
    }
}
