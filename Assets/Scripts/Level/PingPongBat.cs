using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBat : PlayerFollower
{
    public Transform soccer;
    public Transform pingpong;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform trans = collision.collider.GetComponent<Transform>();
        if (soccer == trans)// && (player.CurVelocity.x * (m_rigidbody.position.x - player.transform.position.x)) > 0)
        {
            gameObject.SetActive(false);
        }
    }

    protected override void UpdateTarget()
    {
        target = PlayerBase.PlayerInstance.transform;
        if (soccer.position.x > target.position.x)
            target = soccer;
        if (pingpong.position.x > target.position.x)
            target = pingpong;
    }
}
