using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

    [Header("Available Places")]
    public GameObject[] places;

    [Header("Manual Triggers")]
    public GameObject place1Triggers;
    public GameObject place2Triggers;
    public GameObject place3Triggers;
    public GameObject place14Triggers;

    [Header("Static Objects")]
    public GameObject place9_10_23;
    public GameObject place17_18_19;
    public GameObject place20_21_22_26_27;

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
    public bool place26Active;
    public bool place27Active;
    public bool place28Active;
    public bool place29Active;
    public bool place30Active;

    [Header("Announcers")]
    public Text stateText;

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
        if (place1Active)
        {
            place1Triggers.SetActive(true);
        }
        else
        {
            place1Triggers.SetActive(false);
        }

        if (place2Active)
        {
            place2Triggers.SetActive(true);
        }
        else
        {
            place2Triggers.SetActive(false);
        }

        if (place3Active)
        {
            place3Triggers.SetActive(true);
        }
        else
        {
            place3Triggers.SetActive(false);
        }

        if (place14Active)
        {
            place14Triggers.SetActive(true);
        }
        else
        {
            place14Triggers.SetActive(false);
        }

        if (place9Active || place10Active || place23Active)
        {
            place9_10_23.SetActive(true);
        }
        else
        {
            place9_10_23.SetActive(false);
        }

        if (place17Active || place18Active || place19Active)
        {
            place17_18_19.SetActive(true);
        }
        else
        {
            place17_18_19.SetActive(false);
        }

        if (place20Active || place21Active || place22Active || place26Active || place27Active)
        {
            place20_21_22_26_27.SetActive(true);
        }
        else
        {
            place20_21_22_26_27.SetActive(false);
        }
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place1);
            }
            else if (obj.tag == "Place2" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place2);
            }
            else if (obj.tag == "Place3" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place3);
            }
            else if (obj.tag == "Place4" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place4);
            }
            else if (obj.tag == "Place5" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place5);
            }
            else if (obj.tag == "Place6" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place6);
            }
            else if (obj.tag == "Place7" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place7);
            }
            else if (obj.tag == "Place8" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place8);
            }
            else if (obj.tag == "Place9" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place9);
            }
            else if (obj.tag == "Place10" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place10);
            }
            else if (obj.tag == "Place11" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place11);
            }
            else if (obj.tag == "Place12" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place12);
            }
            else if (obj.tag == "Place13" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place13);
            }
            else if (obj.tag == "Place14" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place14);
            }
            else if (obj.tag == "Place15" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place15);
            }
            else if (obj.tag == "Place16" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place16);
            }
            else if (obj.tag == "Place17" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place17);
            }
            else if (obj.tag == "Place18" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place18);
            }
            else if (obj.tag == "Place19" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place19);
            }
            else if (obj.tag == "Place20" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place20);
            }
            else if (obj.tag == "Place21" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place21);
            }
            else if (obj.tag == "Place22" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place22);
            }
            else if (obj.tag == "Place23" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place23);
            }
            else if (obj.tag == "Place24" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place24);
            }
            else if (obj.tag == "Place25" && obj.activeInHierarchy)
            {
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
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place25);
            }
            else if (obj.tag == "Place26" && obj.activeInHierarchy)
            {
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
                place25Active = false;
                place26Active = true;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place26);
            }
            else if (obj.tag == "Place27" && obj.activeInHierarchy)
            {
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
                place25Active = false;
                place26Active = false;
                place27Active = true;
                place28Active = false;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place27);
            }
            else if (obj.tag == "Place28" && obj.activeInHierarchy)
            {
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
                place25Active = false;
                place26Active = false;
                place27Active = false;
                place28Active = true;
                place29Active = false;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place28);
            }
            else if (obj.tag == "Place29" && obj.activeInHierarchy)
            {
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
                place25Active = false;
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = true;
                place30Active = false;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place29);
            }
            else if (obj.tag == "Place30" && obj.activeInHierarchy)
            {
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
                place25Active = false;
                place26Active = false;
                place27Active = false;
                place28Active = false;
                place29Active = false;
                place30Active = true;
                MazeUtility.AnnounceState(stateText, MazeAnnouncer.Place30);
            }
        }
    }
}
