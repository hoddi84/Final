using System;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    public GameObject unitA;
    public GameObject unitB;
    public GameObject unitD;

    Dictionary<TestUnit, GameObject> pathDict = new Dictionary<TestUnit, GameObject>();

    private Action<TestUnit, GameObject> onInstantiate = null;

    private void Awake()
    {
        onInstantiate += UpdatePathDictionary;
    }

    private void Start()
    {
        GameObject tmp = Instantiate(unitA);
        TestTrigger trigger = tmp.GetComponentInChildren<TestTrigger>();

        RegisterListeners(tmp);

        if (onInstantiate != null)
        {
            onInstantiate(trigger.isType, tmp);
        }
    }

    private void InstantiateUnit(TestTrigger trigger)
    {
        GameObject tmp = null;

        switch (trigger.toType)
        {
            case TestUnit.TypeA:

                if (!pathDict.ContainsKey(TestUnit.TypeA))
                {
                    tmp = Instantiate(unitA);
                }
                else
                {
                    GameObject t;
                    pathDict.TryGetValue(TestUnit.TypeA, out t);
                    if (!t.activeInHierarchy)
                    {
                        t.SetActive(true);
                    }
                    else
                    {
                        t.SetActive(false);
                    }
                }
                break;

            case TestUnit.TypeB:

                if (!pathDict.ContainsKey(TestUnit.TypeB))
                {
                    tmp = Instantiate(unitB);
                }
                else
                {
                    GameObject t;
                    pathDict.TryGetValue(TestUnit.TypeB, out t);
                    if (!t.activeInHierarchy)
                    {
                        t.SetActive(true);
                    }
                    else
                    {
                        t.SetActive(false);
                    }
                }
                break;

            case TestUnit.TypeD:

                if (!pathDict.ContainsKey(TestUnit.TypeD))
                {
                    tmp = Instantiate(unitD);
                }
                else
                {
                    GameObject t;
                    pathDict.TryGetValue(TestUnit.TypeD, out t);
                    if (!t.activeInHierarchy)
                    {
                        t.SetActive(true);
                    }
                    else
                    {
                        t.SetActive(false);
                    }
                }
                break;             
        }

        if (tmp != null)
        {
            RegisterListeners(tmp);
        }

        if (onInstantiate != null)
        {
            onInstantiate(trigger.toType, tmp);
        }
    }

    private void UpdatePathDictionary(TestUnit unitType, GameObject obj)
    {
        if (!pathDict.ContainsKey(unitType))
        {
            pathDict.Add(unitType, obj);
        }
    }

    private void RegisterListeners(GameObject unit)
    {
        if (unit.GetComponentsInChildren<TestTrigger>() != null)
        {
            TestTrigger[] triggers = unit.GetComponentsInChildren<TestTrigger>();

            foreach (TestTrigger trigger in triggers)
            {
                trigger.onTriggerEntered += InstantiateUnit;
            }
        }
    }
}
