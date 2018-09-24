using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollision(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided");
            Destroy(col.gameObject);
        }
    }
}
