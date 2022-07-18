using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMirror : MonoBehaviour
{
    public int mirrorDir = 0;//0-Ë®Æ½ 1-×ÝÏò
    public MessageObstacle obstacle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MessageBall ball = collision.collider.GetComponent<MessageBall>();
        if (ball)
        {
            int dir = mirrorDir;
            switch (mirrorDir)
            {
                case 0:
                    dir = transform.position.y < ball.transform.position.y ? 0 : 2;
                    break;
                case 1:
                    dir = transform.position.x < ball.transform.position.x ? 1 : 3;
                    break;
                default:
                    break;
            }
            ball.Reflect(dir);
            if (obstacle)
                Destroy(obstacle.gameObject);
        }
    }
}
