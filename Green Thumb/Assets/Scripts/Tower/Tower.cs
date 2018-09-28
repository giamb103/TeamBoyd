using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform gunEnd;
    public GameObject bullet;
    public GameObject[] validTargets;
    public GameObject curTarget;
    float closestDist = 0.0f;

    // Use this for initialization
    void Start()
    {
        validTargets = GameObject.FindGameObjectsWithTag("Enemy");//put all enemies into array
        curTarget = null;

        if (validTargets.Length != 0)
        {
            for (int i = 0; i < validTargets.Length; i++)
            {//sort array to have closest enemy in array[0]
                float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);//calculates distance from tower to enemy

                if (!curTarget || dist < closestDist)
                {
                    curTarget = validTargets[i];
                    closestDist = dist;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        validTargets = GameObject.FindGameObjectsWithTag("Enemy");//put all enemies into array
        curTarget = null;
        
		if (validTargets.Length != 0) {
			for (int i = 0; i < validTargets.Length; i++) {//sort array to have closest enemy in array[0]
				float dist = Vector3.Distance (transform.position, validTargets [i].transform.position);//calculates distance from tower to enemy

				if (!curTarget || dist < closestDist) {
					curTarget = validTargets [i];
					closestDist = dist;
				}
			}
		}
		if (curTarget != null) {
			Debug.Log ("curtarget != null");
			Vector3 targetPos = new Vector3 (curTarget.transform.position.x, transform.position.y, curTarget.transform.position.z);//target vector where enemy currently is
			transform.LookAt (targetPos);//aim turret at enemy
		} 
		else 
		{
			//TODO: lock rotation if curtarget is null
			Debug.Log ("curtarget = null");
		}
    }	

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
            StartCoroutine("Fire");
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
            StopCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
