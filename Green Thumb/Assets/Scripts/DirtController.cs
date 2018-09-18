using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour {

    public GameObject smallPlant;

    private bool hasBeenSeeded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        //tool interacts with dirt
        if (collision.gameObject.tag == "Tool" && Input.GetKeyDown(KeyCode.Return) && !hasBeenSeeded)
        {
            //Destroy(gameObject);
            Instantiate(smallPlant, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            hasBeenSeeded = true;
        }
    }

}
