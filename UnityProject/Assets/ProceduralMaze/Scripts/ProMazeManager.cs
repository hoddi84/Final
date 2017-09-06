using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProMazeManager : MonoBehaviour {

    public GameObject[] unitType0;
    public GameObject[] unitTypeA;
    public GameObject[] unitTypeB;

    private GameObject previousUnit = null;
    private GameObject currentUnit = null;

    private void Start()
    {
        int rndIndex = Random.Range(0, unitType0.Length);
        currentUnit = Instantiate(unitType0[rndIndex].gameObject);
        currentUnit.GetComponent<ProType>().onTriggerEntered += SpawnNextUnit;
    }

    void SpawnNextUnit(GameObject nextUnit, UnitType unitType, UnitType unitTypeConnecter)
    {
        ProType nextType = nextUnit.GetComponent<ProType>();

        previousUnit = currentUnit;
        previousUnit.GetComponent<ProType>().onTriggerEntered = null;

        int rndIndex;

        switch (nextType.unitTypeConnecter)
        {
            case UnitType.Type_A:

                rndIndex = Random.Range(0, unitTypeA.Length);
                currentUnit = Instantiate(unitTypeA[rndIndex].gameObject);
                break;

            case UnitType.Type_B:

                rndIndex = Random.Range(0, unitTypeB.Length);
                currentUnit = Instantiate(unitTypeB[rndIndex].gameObject);
                break;
        }
        UpdateActiveUnitSender(currentUnit);
    }

    void UpdateActiveUnitSender(GameObject newSender)
    {
        newSender.GetComponent<ProType>().onTriggerEntered = SpawnNextUnit;
    }
}
