using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBox : MonoBehaviour {

    public int SellsFor = 5;
    public GameObject moneyText;
    //public GameObject gm;

    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            moneyText.SetActive(false);
        }
		
	}

    private void OnTriggerStay(Collider other)
    {
        //drop fruit in sell box, add money and display it
        if (other.tag == "Plant" && Input.GetKey(KeyCode.E))
        {
            Destroy(other.gameObject);
            //gm.addMoney(SellsFor);
            timer = 2;
            moneyText.GetComponent<TextMesh>().text = "+" + SellsFor;
            moneyText.SetActive(true);
        }
    }
}
