using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProTypeManager : MonoBehaviour {

    public GameObject[] unitType0;
    public GameObject[] unitTypeA;
    public GameObject[] unitTypeB;

    private GameObject currentUnit = null;

    private List<GameObject> listOfInstantiated = new List<GameObject>();

    private const int startOfTypeIndex = 6;

    private void Start()
    {
        int rndIndex = Random.Range(0, unitType0.Length);
        currentUnit = Instantiate(unitType0[rndIndex]);

        AddSenders(currentUnit);

        AddToInstantiatedList(currentUnit);

        currentUnit = null;
    }

    private void InstantiateConnectedUnit(GameObject obj, UnitType isType, UnitType toType)
    {
        int rndIndex = 0;

        switch(toType)
        {
            case UnitType.TypeA:

                // TODO: Make this more generic.
                if (currentUnit != null)
                {
                    List<char> types = GetUnitTypes(currentUnit);
                    foreach (char c in types)
                    {
                        if (c != 'A')
                        {
                            listOfInstantiated.Remove(currentUnit);
                            Destroy(currentUnit);
                            break;
                        }
                    }
                }

                rndIndex = Random.Range(0, unitTypeA.Length);
                currentUnit = Instantiate(unitTypeA[rndIndex]);
                break;
            case UnitType.TypeB:

                //TODO: Make this more generic.
                if (currentUnit != null)
                {
                    List<char> types = GetUnitTypes(currentUnit);
                    foreach (char c in types)
                    {
                        if (c != 'B')
                        {
                            listOfInstantiated.Remove(currentUnit);
                            Destroy(currentUnit);
                            break;
                        }
                    }
                }

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
    void AddToInstantiatedList(GameObject newInstantiateUnit)
    {
        listOfInstantiated.RemoveAll(existingUnit => CheckForDuplicateUnit(existingUnit, newInstantiateUnit));

        listOfInstantiated.Add(newInstantiateUnit);
    }

    bool CheckForDuplicateUnit(GameObject existingUnit, GameObject newInstantiatedUnit)
    {
        List<char> newTypes = GetUnitTypes(newInstantiatedUnit);
        List<char> existingTypes = GetUnitTypes(existingUnit);

        foreach (char newType in newTypes)
        {
            foreach (char existingType in existingTypes)
            {
                if (newType == existingType)
                {
                    Destroy(existingUnit);
                    return true;
                }
            }
        }
        return false;
    }

    /*
     * Returns the unit types from a unit object.
     * Stores them as chars in a list.
     * Units must follow a naming convention such as "isTypeABC",
     * where the unit types from this unit are A, B and C.
     */
    private List<char> GetUnitTypes(GameObject obj)
    {
        List<char> types = new List<char>();

        string[] name = obj.name.Split('_');
        string type = name[0];

        for (int i = startOfTypeIndex; i < type.Length; i++)
        {
            types.Add(type[i]);
        }
        return types;
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
