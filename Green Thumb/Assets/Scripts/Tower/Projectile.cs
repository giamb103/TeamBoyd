using UnityEngine;
using System.Collections;
 
public class NormalProjectile : BaseProjectile
{
    Vector3 m_direction;
    bool m_fired;
    GameObject m_target;

    // Update is called once per frame
    void Update()
    {
        if (m_fired)
        {
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, float attackSpeed)
    {
        if (launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            m_target = target;

            Destroy(gameObject, 10.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == m_target)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<BaseProjectile>() == null)
            Destroy(gameObject);
    }
}