using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public int damage = 5;
    public int health;
    public float speed = 2.0f;
    private Rigidbody rb;
    public string targetTag = "";
    int enemyHealth;
    PlantScript plant;
    Tower tower;
    public GameObject health_text;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (targetTag == null)
            targetTag = "Plant";
    }

    // Update is called once per frame
    void Update()
    {
        health_text.GetComponent<TextMesh>().text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 start = transform.position;
        GameObject[] validTargets = GameObject.FindGameObjectsWithTag(targetTag);//array of all plants
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
	        Vector3 end = curTarget.transform.position;//get the posiiton of closest target
	        Vector3 newPosition = Vector3.MoveTowards(start, end, speed);//move enemy towards targe
			rb.MovePosition(newPosition);
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Plant")
        {
            plant = col.gameObject.GetComponent<PlantScript>();

            enemyHealth = plant.getHealth();
            enemyHealth -= damage;
            plant.setHealth(enemyHealth);

        }

        if (col.gameObject.tag == "Turret")
        {
            Debug.Log("Turret");
            tower = col.gameObject.GetComponent<Tower>();

            enemyHealth = tower.getHealth();
            enemyHealth -= damage;
            tower.setHealth(enemyHealth);

        }

        if (col.gameObject.tag == "Bullet")
        {
            health -= 5;
        }
    }

    void onTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Plant")
        {
            enemyHealth = plant.getHealth();
            enemyHealth -= damage;
            plant.setHealth(enemyHealth);

        }

        if (col.gameObject.tag == "Turret")
        {
            Debug.Log("Hit Turret");
            enemyHealth = tower.getHealth();
            enemyHealth -= damage;
            tower.setHealth(enemyHealth);

        }
    }
}