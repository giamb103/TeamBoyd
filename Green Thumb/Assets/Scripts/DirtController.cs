using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour {

    public GameObject seed;
    public GameObject timer; 

    private bool hasBeenSeeded = false;

    private GameObject plantObject;
    private GameObject timerObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /*checks if there's a timer and if there is, checks if it's zero
        if so, it deletes the seed gameobject and the timer, and sets hasBeenSeeded to false 
        so that the dirt patch can be re-seeded*/

        if (timerObject != null)
        {
            if (timerObject.GetComponent<Timer>().timer < 0f)
            {
                Destroy(plantObject);
                Destroy(timerObject);
                hasBeenSeeded = false;
            }
        }
	}

    private void OnCollisionStay(Collision collision)
    {

        //if the player is holding a tool and presses enter and the patch doesn't already have a seed,
        //instantiate a seed and a timer and set hasBeenSeeded to true

        if (collision.gameObject.tag == "Tool" && Input.GetKeyDown(KeyCode.Return) && !hasBeenSeeded)
        {
            plantObject = Instantiate(seed, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            timerObject = Instantiate(timer, new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
            hasBeenSeeded = true;
        }
    }

}
