using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMirror : MonoBehaviour
{
    public int mirrorDir = 0;//0-Ë®Æ½ 1-×ÝÏò

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MessageBall ball = collision.collider.GetComponent<MessageBall>();
        if (ball)
        {
            ball.Reflect(mirrorDir);
        }
    }
}
