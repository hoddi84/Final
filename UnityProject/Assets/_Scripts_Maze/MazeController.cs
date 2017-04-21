using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

    [Header("Available Places")]
    public GameObject[] places;

    private GameObject currentPlace = null;

    [Header("Branching Places")]
    public GameObject[] place1;

    private GameObject[] currentBranchingPlaces;

    private int branchingCounter = 0;
    private bool branchingCounterActivated = false;

    [Header("States")]
    public bool place1Active;
    public bool place2Active;
    public bool place3Active;
    public bool place4Active;
    public bool place5Active;
    public bool place6Active;
    public bool place7Active;
    public bool place8Active;
    public bool place9Active;
    public bool place10Active;

    [Header("Announcers")]
    public Text stateText;
    public Text branchText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        CheckCurrentState();
	}

    void UpdateBranchingInformation(GameObject[] branchingPlaces, GameObject place)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            branchingCounter++;
        }
        if (branchingPlaces != null)
        {
            if (branchingCounter >= branchingPlaces.Length)
            {
                branchingCounter = 0;
            }
        }
        MazeUtility.AnnounceBranch(branchText, place.tag, branchingPlaces, branchingCounter);
    }

    void CheckCurrentState()
    {
        foreach (GameObject obj in places)
        {
            if (obj.tag == "Place1" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = place1;
                place1Active = true;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place1);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place2" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = true;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place2);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place3" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = true;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place3);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place4" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = true;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place4);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place5" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = true;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place5);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place6" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = true;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place6);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place7" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = true;
                place8Active = false;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place7);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place8" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = true;
                place9Active = false;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place8);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place9" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = true;
                place10Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place9);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place10" && obj.activeInHierarchy)
            {
                currentPlace = obj;
                currentBranchingPlaces = null;
                place1Active = false;
                place2Active = false;
                place3Active = false;
                place4Active = false;
                place5Active = false;
                place6Active = false;
                place7Active = false;
                place8Active = false;
                place9Active = false;
                place10Active = true;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place10);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
        }
    }
}
