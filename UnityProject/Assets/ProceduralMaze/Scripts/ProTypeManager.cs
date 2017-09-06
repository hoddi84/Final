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

    public GameObject unittest;

    private void Start()
    {
        int rndIndex = Random.Range(0, unitType0.Length);
        currentUnit = Instantiate(unitType0[rndIndex]);

        AddSenders(currentUnit);

        AddToInstantiatedList(currentUnit);

        currentUnit = null;
    }

    /*
     * This here makes sure that we do not destroy a previous unit when that unit
     * is being connected to a unit that is also connected to this unit.
     */
    private bool DoesCurrentInstantiateSimilar(GameObject currentUnit, UnitType unitType)
    {
        List<char> typeList = new List<char>();
        bool match = false;

        if (currentUnit.GetComponentsInChildren<ProType>() != null)
        {
            ProType[] types = currentUnit.GetComponentsInChildren<ProType>();

            foreach (ProType type in types)
            {
                List<char> t = GetUnitTypes(type.unitTypeConnecter);
                foreach (char x in t)
                {
                    typeList.Add(x);
                }
            }
        }

        List<char> unitTypeList = GetUnitTypes(unitType);

        foreach (char currType in typeList)
        {
            foreach (char uType in unitTypeList)
            {
                if (currType == uType)
                {
                    match = true;
                    goto end;
                }
            }
        }
        end:
        if (match)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InstantiateConnectedUnit(GameObject obj, UnitType isType, UnitType toType)
    {
        int rndIndex = 0;

        switch(toType)
        {
            case UnitType.Type_A:

                if (currentUnit != null)
                {
                    DestroyPreviousDifferentUnit(UnitType.Type_A, currentUnit);
                }

                rndIndex = Random.Range(0, unitTypeA.Length);
                currentUnit = Instantiate(unitTypeA[rndIndex]);
                break;
            case UnitType.Type_B:

                if (currentUnit != null)
                {
                    DestroyPreviousDifferentUnit(UnitType.Type_B, currentUnit);
                }

                rndIndex = Random.Range(0, unitTypeB.Length);
                currentUnit = Instantiate(unitTypeB[rndIndex]);
                break;
            case UnitType.Type_0:

                if (currentUnit != null)
                {
                    DestroyPreviousDifferentUnit(UnitType.Type_0, currentUnit);
                }

                rndIndex = Random.Range(0, unitType0.Length);
                currentUnit = Instantiate(unitType0[rndIndex]);
                break;
        }
        AddToInstantiatedList(currentUnit);
        AddSenders(currentUnit);
    }

    /*
     * When instantiating a new unit, if the instantiated unit is of a different
     * type than the current unit, then we destroy the current unit.
     * Such that we can always remove units behind us.
     */
    private void DestroyPreviousDifferentUnit(UnitType type, GameObject currentUnit)
    {
        bool match = FoundMatch(currentUnit, type);

        if (!match)
        {
            listOfInstantiated.Remove(currentUnit);
            Destroy(currentUnit);
        }
    }

    private bool FoundMatch(GameObject obj, UnitType type)
    {
        List<char> typesOnObj = GetUnitTypes(obj);
        List<char> typesOnUnit = GetUnitTypes(type);

        bool matchFound = false;

        foreach (char objType in typesOnObj)
        {
            foreach (char unitType in typesOnUnit)
            {
                if (objType == unitType)
                {
                    matchFound = true;
                    goto end;
                }
            }
        }
        end:
        if (matchFound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
     * Adds instantiated gameobjects to a list, which we can use
     * to remove an existing unit of the same type as the unit being
     * instantiated.
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

    private List<char> GetUnitTypes(UnitType type)
    {
        List<char> unitTypeList = new List<char>();
        string[] types = type.ToString().Split('_');
        string unitTypes = types[1];

        foreach (char c in unitTypes)
        {
            unitTypeList.Add(c);
        }
        return unitTypeList;
    }

    void AddSenders(GameObject sender)
    {
        if (sender.GetComponentsInChildren<ProType>() != null)
        {
            ProType[] types = sender.GetComponentsInChildren<ProType>();

            foreach (ProType type in types)
            {
                type.onTriggerEntered += InstantiateConnectedUnit;
            }
        }
    }
}
