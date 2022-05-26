using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    public float Speed = 0;

    private Vector2 m_curMoveDir;

    void Update()
    {
        UpdateMove();
        transform.Translate(m_curMoveDir * Speed * Time.deltaTime);
    }

    protected virtual void UpdateMove()
    {
        MoveH(0);
        MoveV(0);
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
