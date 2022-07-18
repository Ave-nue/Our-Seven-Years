using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBall : MonoBehaviour
{
    public float startVel;
    public float maxVVel;

    private Rigidbody2D m_rigidbody;

    private bool m_isActive;
    public bool IsActive
    {
        get { return m_isActive; }
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        gameObject.SetActive(true);
        Vector2 startVec = new Vector2(-1f, 1f);
        startVec.y = Mathf.Sign(Random.Range(-1, 1));
        startVec = startVec.normalized * startVel;
        m_rigidbody.velocity = startVec;
        float angle = Vector2.SignedAngle(Vector2.right, m_rigidbody.velocity);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        m_isActive = true;
    }

    public void Reflect(int dir, float offset = 0f)
    {
        Vector2 newVel = m_rigidbody.velocity;
        switch (dir)
        {
            case 0:
                newVel.y = Mathf.Abs(newVel.y);
                break;
            case 1:
                newVel.x = Mathf.Abs(newVel.x);
                break;
            case 2:
                newVel.y = -Mathf.Abs(newVel.y);
                break;
            case 3:
                newVel.x = -Mathf.Abs(newVel.x);
                break;
            default:
                break;
        }

        newVel.y += offset * 0.3f;

        float curVVel = Mathf.Abs(newVel.y);
        if (curVVel > maxVVel)
            newVel.y = newVel.y / curVVel * maxVVel;

        m_rigidbody.velocity = newVel;

        float angle = Vector2.SignedAngle(Vector2.right, m_rigidbody.velocity);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
