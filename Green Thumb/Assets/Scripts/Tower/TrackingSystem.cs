using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrackingSystem : MonoBehaviour {
    public float speed = 10.0f;

   public GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
            if (m_lastKnownPosition != m_target.transform.position)
            {
                m_lastKnownPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    public bool SetTarget(GameObject target)
    {
        if (!target)
            return false;

        m_target = target;

        return true;
    }
}
