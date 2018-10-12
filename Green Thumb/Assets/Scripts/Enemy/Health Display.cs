using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {
    public GameObject HealthObj;
    int health;
    private void Start()
    {
        health = 0;
     }

    void Update()
    {
        HealthObj.GetComponent<TextMesh>().text = health.ToString();
        if (health < 5.1)
        {
            HealthObj.GetComponent<TextMesh>().color = Color.red;
        }
    }
}
