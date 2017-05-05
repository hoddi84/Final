using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectToggler : MonoBehaviour {

    public GameObject objectsDefault;
    public GameObject objectsActive;

    public Sprite spriteDefault;
    public Sprite spriteActive;

    private bool showingDefault = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        if (showingDefault)
        {
            objectsDefault.SetActive(false);
            objectsActive.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteActive;
            showingDefault = false;
        }
        else
        {
            objectsDefault.SetActive(true);
            objectsActive.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteDefault;
            showingDefault = true;
        }
    }
}
