using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGirl : PlayerBase
{
    protected override void Awake()
    {
        base.Awake();

        GirlInstance = this;
    }

    public override void DealInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GoLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GoRight();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GoRight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GoLeft();
        }

        Move(m_dirFactor);
        if (m_dirFactor != 0)
            spriteRenferer.flipX = m_dirFactor > 0;
        animator.SetBool("Walking", m_dirFactor != 0);
        animator.SetBool("Jumping", m_remainJumpCount < jumpCount);
    }

    public override void GoLeft()
    {
        m_dirFactor += 1.0f;
    }

    public override void GoRight()
    {
        m_dirFactor += -1.0f;
    }

    protected override void Dead()
    {
        base.Dead();
        SavePoint.CurSavePoint_Boy?.Revive(BoyInstance);
        SavePoint.CurSavePoint_Girl?.Revive(GirlInstance);
    }
}
