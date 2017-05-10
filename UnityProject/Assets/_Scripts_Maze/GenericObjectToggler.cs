using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectToggler : MonoBehaviour {

    public GameObject objectsDefault;
    public GameObject objectsActive;

    public Sprite spriteDefault;
    public Sprite spriteActive;

    private bool showingDefault = true;

    /*
     * This is done to reset the state, e.g. so that when we
     * come back to a previous state we have reset the settings.
     */
    void OnDisable()
    {
        showingDefault = false;
        Toggle();
    }


    public void Toggle()
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
