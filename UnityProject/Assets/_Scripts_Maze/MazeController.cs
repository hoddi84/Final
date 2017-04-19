using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

    [Header("Available Places")]
    public GameObject[] places;

    [Header("States")]
    public bool place1Active;
    public bool place2Active;
    public bool place3Active;
    public bool place4Active;

    [Header("Announcers")]
    public Text stateText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CheckCurrentState();
	}

    void CheckCurrentState()
    {
        foreach (GameObject obj in places)
        {
            if (obj.tag == "Place1" && obj.activeInHierarchy)
            {
                place1Active = true;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place1);
            }
            else if (obj.tag == "Place2" && obj.activeInHierarchy)
            {
                place1Active = false;
                place2Active = true;
                place3Active = false;
                place4Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place2);
            }
            else if (obj.tag == "Place3" && obj.activeInHierarchy)
            {
                place1Active = false;
                place2Active = false;
                place3Active = true;
                place4Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place3);
            }
            else if (obj.tag == "Place4" && obj.activeInHierarchy)
            {
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = true;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place4);
            }
        }
    }
}
