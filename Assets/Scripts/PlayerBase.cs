using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : PhysicsBase
{
    public static PlayerBase PlayerInstance;

    public Soccer soccer;

    protected override void Awake()
    {
        base.Awake();

        PlayerInstance = this;
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

        float dirFactor = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirFactor += 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirFactor += -1f;
        }
        Move(dirFactor);
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

    private void Dead()
    {
        Debug.Log("นามหฃก");
        SavePoint.CurSavePoint?.Revive(this);
    }

    public void Revive()
    {

    }
}
