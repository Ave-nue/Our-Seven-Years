using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    //[HideInInspector]
    public Transform target;

    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateTarget();
        UpdatePosition();
    }

    protected virtual void UpdateTarget()
    {

    }

    private void UpdatePosition()
    {
        if (!target)
            return;

        if (m_rigidbody)
        {
            m_rigidbody.MovePosition(new Vector2(m_rigidbody.position.x, target.transform.position.y));
        }
        else
        {
            transform.Translate(Vector3.up * (target.transform.position.y - transform.position.y));
        }
    }
}
