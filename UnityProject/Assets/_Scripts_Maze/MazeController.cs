using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

    [Header("Available Places")]
    public GameObject[] places;

    private GameObject currentPlace = null;

    [Header("Manual Triggers")]
    public GameObject place2Triggers;

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
    public bool place11Active;
    public bool place12Active;
    public bool place13Active;
    public bool place14Active;
    public bool place15Active;
    public bool place16Active;
    public bool place17Active;
    public bool place18Active;
    public bool place19Active;
    public bool place20Active;
    public bool place21Active;
    public bool place22Active;
    public bool place23Active;
    public bool place24Active;
    public bool place25Active;

    [Header("Announcers")]
    public Text stateText;
    public Text branchText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        CheckCurrentState();

        CheckForTriggerArea();
	}

    /*
     * Check which area we are currently in and enable the triggers
     * if applicable.
     */
     void CheckForTriggerArea()
    {
        if (place2Active)
        {
            place2Triggers.SetActive(true);
        }
        else
        {
            place2Triggers.SetActive(false);
        }
    }

    /*
     * Displays available branching points depending on the state we are in.
     */
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

    /*
     * Check which state we are currently in and displaying relevant
     * information.
     */
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
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
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place10);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place11" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = true;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place11);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place12" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = true;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place12);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place13" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = true;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place13);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place14" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = true;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place14);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place15" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = true;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place15);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place16" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = true;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place16);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place17" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = true;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place17);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place18" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = true;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place18);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place19" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = true;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place19);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place20" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = true;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place20);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place21" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = true;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place21);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place22" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = true;
                place23Active = false;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place22);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place23" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = true;
                place24Active = false;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place23);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place24" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = true;
                place25Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place24);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
            else if (obj.tag == "Place25" && obj.activeInHierarchy)
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
                place10Active = false;
                place11Active = false;
                place12Active = false;
                place13Active = false;
                place14Active = false;
                place15Active = false;
                place16Active = false;
                place17Active = false;
                place18Active = false;
                place19Active = false;
                place20Active = false;
                place21Active = false;
                place22Active = false;
                place23Active = false;
                place24Active = false;
                place25Active = true;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place25);
                UpdateBranchingInformation(currentBranchingPlaces, currentPlace);
            }
        }
    }
}
