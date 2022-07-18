using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : PhysicsBase
{
    public static PlayerBase PlayerInstance;
    public static PlayerBase BoyInstance;
    public static PlayerBase GirlInstance;

    public SpriteRenderer spriteRenferer;
    public Animator animator;
    public Soccer soccer;

    protected float m_dirFactor;

    protected override void Awake()
    {
        base.Awake();

        EventManager.Instance.AddListener("PlayerController_Left_Down", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Left_Up", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Down", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Up", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Jump", Jump);
        EventManager.Instance.AddListener("PlayerController_Use", Use);

        PlayerInstance = this;
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerController_Left_Down", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Left_Up", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Down", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Up", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Jump", Jump);
        EventManager.Instance.SubListener("PlayerController_Use", Use);
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
            spriteRenferer.flipX = m_dirFactor < 0;
        animator.SetBool("Walking", m_dirFactor != 0);
        animator.SetBool("Jumping", m_remainJumpCount < jumpCount);
    }

    public virtual void GoLeft()
    {
        m_dirFactor += -1.0f;
    }

    public virtual void GoRight()
    {
        m_dirFactor += 1.0f;
    }

    public void Use()
    {
        if (soccer)
            soccer.KickOut();
    }

    public void Kill()
    {
        Dead();
    }

    protected virtual void Dead()
    {
        Debug.Log("挂了！");
        EventManager.Instance.Trigger("PlayerDead");
        //SavePoint.CurSavePoint?.Revive(this);//这条应该在点击UI复活后才触发
    }

    public void Revive()
    {
        EventManager.Instance.Trigger("PlayerRevive");
    }
}
