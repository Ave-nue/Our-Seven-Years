using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soccer : PhysicsBase
{
    public PlayerBase ballHandler;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        PlayerBase player = collision.collider.GetComponent<PlayerBase>();
        if (player)// && (player.CurVelocity.x * (m_rigidbody.position.x - player.transform.position.x)) > 0)
        {
            ballHandler = player;
            player.soccer = this;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public override void DealInput()
    {
        if (ballHandler)
            m_rigidbody.MovePosition(ballHandler.CurHandlePosition);
    }

    public void KickOut()
    {
        m_rigidbody.velocity = ballHandler.CurVelocity + Vector2.one * moveSpeed;
        ballHandler.soccer = null;
        ballHandler = null;
        GetComponent<Collider2D>().isTrigger = false;
    }
}
