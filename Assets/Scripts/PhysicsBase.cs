using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBase : MonoBehaviour
{
    public float gravity;
    public int jumpCount;
    public float jumpSpeed;
    public float moveSpeed;

    protected Rigidbody2D m_rigidbody;
    protected Vector2 m_curFrameVelocity;
    protected Vector2 m_lastFrameVelocity;
    protected int m_remainJumpCount;

    public Vector2 CurVelocity
    {
        get
        {
            return m_curFrameVelocity;
        }
    }
    public Vector2 CurHandlePosition
    {
        get
        {
            return m_rigidbody.position + Vector2.right;
        }
    }

    protected virtual void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        m_curFrameVelocity = m_rigidbody.velocity;
        if (m_curFrameVelocity.magnitude < 0.01f)
            m_curFrameVelocity = Vector2.zero;
        if (m_curFrameVelocity.y == 0f && m_lastFrameVelocity.y < 0f)//ÂäµØ
            OnGround();

        UpdateGravity();
        DealInput();

        m_rigidbody.velocity = m_curFrameVelocity;
        m_lastFrameVelocity = m_rigidbody.velocity;
    }

    public void FixedUpdate()
    {
        //UpdateGravity();
    }

    public virtual void DealInput()
    {

    }

    protected virtual void OnGround()
    {
        m_remainJumpCount = jumpCount;
    }

    protected virtual void UpdateGravity()
    {
        m_curFrameVelocity += Vector2.down * gravity * Time.deltaTime;
    }

    protected virtual void Jump()
    {
        if (m_remainJumpCount <= 0)
            return;

        Vector2 newVelocity = m_rigidbody.velocity;
        newVelocity.y = jumpSpeed;
        m_rigidbody.velocity = newVelocity;
        m_remainJumpCount--;
    }

    protected virtual void Move(float factor)
    {
        m_curFrameVelocity.x = factor * moveSpeed;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground"://Åöµ½µØ
                break;
            default:
                break;
        }
    }
}
