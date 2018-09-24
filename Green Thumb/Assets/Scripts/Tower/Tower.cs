using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Transform enemy;
    public Transform gunEnd;
    public GameObject bullet;

    // Use this for initialization
    void Start()
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

        enemy = curTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(enemy);
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
