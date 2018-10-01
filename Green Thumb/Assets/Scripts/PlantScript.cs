using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour {
    public int health;
	// Use this for initialization
	void Start () {
        health = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(gameObject);
	}

    public void setHealth(int h)
    {
        health = h;
    }

    public int getHealth()
    {
        return health;
    }
}
