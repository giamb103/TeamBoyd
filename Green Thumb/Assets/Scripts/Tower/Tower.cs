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
    bool firing;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (curTarget == null)
        {
            firing = false;
            rb.freezeRotation = true;
            Debug.Log("curtarget = null");
            validTargets = GameObject.FindGameObjectsWithTag("Enemy");//put all enemies into array
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
		if (curTarget != null) {
            firing = true;
            rb.freezeRotation = false;
            Debug.Log("curtarget != null");
            Vector3 targetPos = new Vector3(curTarget.transform.position.x, transform.position.y, curTarget.transform.position.z);//target vector where enemy currently is
            transform.LookAt(targetPos);//aim turret at enemy
        }
    }	

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
            StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        while (firing)
        {
            Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
