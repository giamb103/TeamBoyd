using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public string theTag;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollision(Collision c)
    {
        if (c.gameObject.tag == theTag)
        {
            Debug.Log("Collided");
            Destroy(gameObject);
        }
    }
}
