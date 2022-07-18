using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public float Speed = 0;
    public Rigidbody2D myRigidbody;

    protected float m_moveDirH;
    protected float m_moveDirV;
    private Vector2 m_curMoveDir;

    void Update()
    {
        UpdateMove();
        myRigidbody.velocity = m_curMoveDir * Speed;
    }

    protected virtual void UpdateMove()
    {
        MoveH(0);
        MoveV(0);
    }

    public void GoLeft()
    {
        m_moveDirH += -1.0f;
    }

    public void GoRight()
    {
        m_moveDirH += 1.0f;
    }

    public void GoUp()
    {
        m_moveDirV += 1.0f;
    }

    public void GoDown()
    {
        m_moveDirV += -1.0f;
    }

    protected void MoveH(float dir)
    {
        m_curMoveDir.x = dir;
    }

    protected void MoveV(float dir)
    {
        m_curMoveDir.y = dir;
    }
}
