using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRunning : MonoBehaviour {

    public GameObject zombie;
    public float speed = 5f;
    private Animator anim;
    private bool activate = false;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.J))
        {
            activate = true;
        }

        if (activate)
        {
            anim.SetBool("ZombieRunning", true);
            zombie.transform.Translate(-1 * Time.deltaTime * speed, 0, 0,Space.World);
        }
	}
}
