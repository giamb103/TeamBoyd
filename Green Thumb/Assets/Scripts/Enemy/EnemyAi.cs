using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    //public int damage = 5;
    //public int health = 15;
    public float speed = 2.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = transform.position;
        GameObject[] validTargets = GameObject.FindGameObjectsWithTag("Plant");//array of all plants
        GameObject curTarget = null;
        float closestDist = 0.0f;
		if (validTargets.Length != 0) {
			for (int i = 0; i < validTargets.Length; i++) {//sort array so that closest plant is stored in array[0]
				float dist = Vector3.Distance (transform.position, validTargets [i].transform.position);

				if (!curTarget || dist < closestDist) {
					curTarget = validTargets [i];
					closestDist = dist;
				}
			}
		}
		if (curTarget != null) {
	        Vector3 end = curTarget.transform.position;//get the posiiton of closest plant
	        Vector3 newPosition = Vector3.MoveTowards(start, end, speed);//move enemy towards plant
			rb.MovePosition(newPosition);
		}
    }

    void onCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Plant")
        {
            Debug.Log("Collided");
            Destroy(col.gameObject);
        }
        
        if(col.gameObject.tag == "Bullet")
        {
            Debug.Log("Collided");
            Destroy(gameObject);
        }
    }
}