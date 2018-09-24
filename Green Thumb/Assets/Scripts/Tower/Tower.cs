using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform gunEnd;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] validTargets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject curTarget = null;
        float closestDist = 0.0f;

        for (int i = 0; i < validTargets.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);//calculates distance from tower to enemy

            if (!curTarget || dist < closestDist)
            {
                curTarget = validTargets[i];
                closestDist = dist;
            }
        }

        Vector3 targetPos = new Vector3(curTarget.transform.position.x, transform.position.y, curTarget.transform.position.z);
        transform.LookAt(targetPos);
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
