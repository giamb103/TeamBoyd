﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{

    public GameObject seed;
    public GameObject medPlant;
    public GameObject largePlant;
    public GameObject fruit;
    public GameObject timer;
    public GameObject tower;

    public Material WateredMaterial;
    public Material DryMaterial;

    private bool hasBeenSeeded = false;
    private bool hasBeenWatered = false;
    private bool hasGrown = false;
    private bool isBig = false;

    private GameObject plantObject;
    private GameObject timerObject;
    private GameObject timerObject2;
    private GameObject defenseTower;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //the logic behind the plant cycle

        if (timerObject != null)
        {
            //if the first timer has run out
            if (timerObject.GetComponent<Timer>().timer < 0f)
            {
                //if the plant is large, instantiate the fruit and reset the dirt patch
                if (isBig)
                {
                    Destroy(timerObject);
                    Destroy(plantObject);
                    gameObject.GetComponent<MeshRenderer>().material = DryMaterial;
                    Instantiate(fruit, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 1.25f), Quaternion.identity);
                    hasBeenSeeded = false;
                    hasGrown = false;
                    isBig = false;
                }
                //make the dirt dry and start timer 2 to wait to get watered again
                else
                {
                    Destroy(timerObject);
                    gameObject.GetComponent<MeshRenderer>().material = DryMaterial;
                    hasBeenWatered = false;
                    timerObject2 = Instantiate(timer, new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
                }
            }
        }

        //if the second "dry dirt" timer has run out
        if (timerObject2 != null)
        {
            //if they just let the timer run out, destroy the seed and timer
            if (timerObject2.GetComponent<Timer>().timer < 0f && !hasBeenWatered && !hasGrown)
            {
                Destroy(timerObject2);
                Destroy(plantObject);
            }
            //if they watered the seed, make the plant watered, grow the plant, and start a new timer for next cycle phase
            else if (hasBeenWatered && !hasGrown)
            {
                Destroy(timerObject2);
                Destroy(plantObject);
                plantObject = Instantiate(medPlant, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                hasGrown = true;
            }
            //if they watered the medium plant, make the plant watered, grow the plant, and start a new timer for the next cycle phase.
            else if (hasBeenWatered && hasGrown)
            {
                Destroy(timerObject2);
                Destroy(plantObject);
                plantObject = Instantiate(largePlant, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
                isBig = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //if they use a seed blox, instantiate a seed
        //TODO: check how many seeds you have
        if (collision.gameObject.tag == "SeedBox" && Input.GetKeyDown(KeyCode.Return) && !hasBeenSeeded)
        {
            plantObject = Instantiate(seed, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            hasBeenSeeded = true;
        }

        //if they use the watering can, water the plant and start the first timer
        if (collision.gameObject.tag == "WateringCan" && Input.GetKeyDown(KeyCode.Return) && !hasBeenWatered)
        {
            gameObject.GetComponent<MeshRenderer>().material = WateredMaterial;
            timerObject = Instantiate(timer, new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
            hasBeenWatered = true;
        }

        //TODO: check how many towers you have
        //TODO: make the space unfillable
        if (collision.gameObject.tag == "TowerPlacer" && Input.GetKeyDown(KeyCode.Return) && !hasBeenSeeded)
        {
            Instantiate(tower, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
        }
    }

}