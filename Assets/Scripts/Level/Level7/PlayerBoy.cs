using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoy : PlayerBase
{
    protected override void Awake()
    {
        base.Awake();

        BoyInstance = this;
    }

    protected override void Dead()
    {
        base.Dead();
        SavePoint.CurSavePoint_Boy?.Revive(BoyInstance);
        SavePoint.CurSavePoint_Girl?.Revive(GirlInstance);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        var wife = collision.collider.GetComponent<PlayerGirl>();
        if (wife)
        {
            EventManager.Instance.Trigger("PassLevel");
        }
    }
}
