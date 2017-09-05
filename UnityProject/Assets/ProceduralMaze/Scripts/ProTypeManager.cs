using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProTypeManager : MonoBehaviour {

    public GameObject[] unitType0;
    public GameObject[] unitTypeA;
    public GameObject[] unitTypeB;

    private GameObject currentUnit;

    private List<GameObject> listOfInstantiated = new List<GameObject>();

    private const string isType0 = "isType0";
    private const string isTypeA = "isTypeA";
    private const string isTypeB = "isTypeB";

    private void Start()
    {
        int rndIndex = Random.Range(0, unitType0.Length);
        currentUnit = Instantiate(unitType0[rndIndex]);

        AddSenders(currentUnit);

        AddToInstantiatedList(currentUnit);
    }

    private void InstantiateConnectedUnit(GameObject obj, UnitType isType, UnitType toType)
    {
        int rndIndex = 0;

        switch(toType)
        {
            case UnitType.TypeA:
                rndIndex = Random.Range(0, unitTypeA.Length);
                currentUnit = Instantiate(unitTypeA[rndIndex]);
                break;
            case UnitType.TypeB:
                rndIndex = Random.Range(0, unitTypeB.Length);
                currentUnit = Instantiate(unitTypeB[rndIndex]);
                break;
        }
        AddToInstantiatedList(currentUnit);
    }

    /*
     * Adds instantiated gameobjects to a list, which we can use
     * to remove an existing unit type when we instantiate a unit.
     */
    void AddToInstantiatedList(GameObject newInstantiated)
    {
        string[] name = newInstantiated.name.Split('_');
        string newType = name[0];

        foreach (GameObject x in listOfInstantiated)
        {
            string[] existingName = x.name.Split('_');
            string existingType = existingName[0];

            if (existingType == newType)
            {
                listOfInstantiated.Remove(x);
                Destroy(x);
                break;
            }
        }

        listOfInstantiated.Add(newInstantiated);
    }

    void AddSenders(GameObject sender)
    {
        ProType[] types = sender.GetComponentsInChildren<ProType>();

        foreach (ProType type in types)
        {
            type.onTriggerEntered += InstantiateConnectedUnit;
        }
    }
}
