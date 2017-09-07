using System;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour {

    public GameObject[] unitA;
    public GameObject[] unitB;
    public GameObject[] unitC;
    public GameObject[] unitD;
    public GameObject[] unitE;
    public GameObject[] unitE1;
    public GameObject[] unitE2;

    Dictionary<TestUnit, GameObject> pathDict = new Dictionary<TestUnit, GameObject>();

    private Action<TestUnit, GameObject> onInstantiate = null;

    private void Awake()
    {
        onInstantiate += UpdatePathDictionary;
    }

    private void Start()
    {
        Initialize(unitA);
    }

    private void InstantiateUnit(TestTrigger trigger)
    {

        switch (trigger.toType)
        {
            case TestUnit.TypeA:

                CheckInstantiatedUnit(trigger, TestUnit.TypeA, unitA);
                break;

            case TestUnit.TypeB:

                CheckInstantiatedUnit(trigger, TestUnit.TypeB, unitB);
                break;

            case TestUnit.TypeC:

                CheckInstantiatedUnit(trigger, TestUnit.TypeC, unitC);
                break;

            case TestUnit.TypeD:

                CheckInstantiatedUnit(trigger, TestUnit.TypeD, unitD);
                break;

            case TestUnit.TypeE:

                CheckInstantiatedUnit(trigger, TestUnit.TypeE, unitE);
                break;

            case TestUnit.TypeE1:

                CheckInstantiatedUnit(trigger, TestUnit.TypeE1, unitE1);
                break;

            case TestUnit.TypeE2:

                CheckInstantiatedUnit(trigger, TestUnit.TypeE2, unitE2);
                break;
        }
    }

    private void CheckInstantiatedUnit(TestTrigger trigger, TestUnit type, GameObject[] unit)
    {
        GameObject tmp = null;

        if (!pathDict.ContainsKey(type))
        {
            int rndIndex = UnityEngine.Random.Range(0, unit.Length);
            tmp = Instantiate(unit[rndIndex]);
        }
        else
        {
            InstantiateExistingUnit(type);
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

    private void InstantiateExistingUnit(TestUnit type)
    {
        GameObject t;
        pathDict.TryGetValue(type, out t);

        if (!t.activeInHierarchy)
        {
            t.SetActive(true);
            RegisterListeners(t);
        }
        else
        {
            DeregisterListeners(t);
            t.SetActive(false);
        }
    }

    private void UpdatePathDictionary(TestUnit unitType, GameObject obj)
    {
        if (!pathDict.ContainsKey(unitType))
        {
            pathDict.Add(unitType, obj);
        }
    }

    /// <summary>
    /// Initialize a random starting point Unit from 
    /// the chosen unit type.
    /// </summary>
    /// <param name="unit"></param>
    private void Initialize(GameObject[] unit)
    {
        int rndIndex = UnityEngine.Random.Range(0, unit.Length);
        GameObject tmp = Instantiate(unit[rndIndex]);
        TestTrigger trigger = tmp.GetComponentInChildren<TestTrigger>();

        RegisterListeners(tmp);

        if (onInstantiate != null)
        {
            onInstantiate(trigger.isType, tmp);
        }
    }

    /// <summary>
    /// Register to "onTriggerEntered" events from a gameObject Unit,
    /// that contains a TestTrigger.
    /// </summary>
    /// <param name="unit"></param>
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

    /// <summary>
    /// Deregister to "onTriggeredEntered" events from a gameObject Unit,
    /// that contains a TestTrigger.
    /// </summary>
    /// <param name="unit"></param>
    private void DeregisterListeners(GameObject unit)
    {
        if (unit.GetComponentsInChildren<TestTrigger>() != null)
        {
            TestTrigger[] triggers = unit.GetComponentsInChildren<TestTrigger>();
            
            foreach (TestTrigger trigger in triggers)
            {
                trigger.onTriggerEntered -= InstantiateUnit;
            }
        }
    }
}
