using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
	public int damage = 5;
	public int health = 15;
    public float speed = 2.0f;
    public GameObject plant;
    public Transform target;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        plant = GameObject.FindGameObjectWithTag("Plant");
        target = plant.transform;
        
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 start = transform.position;
        Vector3 end = target.position;
        Vector3 newPosition = Vector3.MoveTowards(start, end, speed);
        rb.MovePosition(newPosition);
	}

    void onCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Plant"))
        {
            col.gameObject.SetActive(false);
        }
    }
}