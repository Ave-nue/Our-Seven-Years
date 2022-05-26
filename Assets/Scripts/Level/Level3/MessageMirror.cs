using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMirror : MonoBehaviour
{
    public int mirrorDir = 0;//0-ˮƽ 1-����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MessageBall ball = collision.collider.GetComponent<MessageBall>();
        if (ball)
        {
            ball.Reflect(mirrorDir);
        }
    }
}
