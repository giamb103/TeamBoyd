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
        //tool interacts with dirt
        if (collision.gameObject.tag == "Tool" && Input.GetKeyDown(KeyCode.Return) && !hasBeenSeeded)
        {
            //Destroy(gameObject);
            plantObject = Instantiate(seed, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            timerObject = Instantiate(timer, new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
            hasBeenSeeded = true;
        }
    }

}
