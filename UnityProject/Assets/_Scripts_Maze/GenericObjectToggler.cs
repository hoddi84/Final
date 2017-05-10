using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectToggler : MonoBehaviour {

    public GameObject objectsDefault;
    public GameObject objectsActive;

    public Sprite spriteDefault;
    public Sprite spriteActive;

    private bool showingDefault = true;

    [Header("Advanced Toggle")]
    public bool enableMultipleToggle = false;
    public GameObject defaultState;
    public GameObject[] activeStates;
    public Sprite defaultSprite;
    public Sprite[] activeSprites;

    private int counter = 0;

    /*
     * This is done to reset the state, e.g. so that when we
     * come back to a previous state we have reset the settings.
     */
    void OnDisable()
    {
        showingDefault = false;
        counter = activeStates.Length + 1;
        Toggle();
    }


    public void Toggle()
    {
        if (enableMultipleToggle)
        {
            counter++;
            if (counter >= (activeStates.Length + 1))
            {
                counter = 0;
            }
            if (counter == 0)
            {
                foreach (GameObject state in activeStates)
                {
                    state.SetActive(false);
                }
                if (defaultState != null)
                {
                    defaultState.SetActive(true);
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            }
            else
            {
                foreach (GameObject state in activeStates)
                {
                    state.SetActive(false);
                }
                activeStates[counter - 1].SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = activeSprites[counter - 1];
            }
        }
        else
        {
            if (showingDefault)
            {
                if (objectsDefault != null)
                {
                    objectsDefault.SetActive(false);

                }
                if (objectsActive != null)
                {
                    objectsActive.SetActive(true);
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteActive;
                showingDefault = false;
            }
            else
            {
                if (objectsDefault != null)
                {
                    objectsDefault.SetActive(true);

                }
                if (objectsActive != null)
                {
                    objectsActive.SetActive(false);
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteDefault;
                showingDefault = true;
            }
        }
        
    }
}
