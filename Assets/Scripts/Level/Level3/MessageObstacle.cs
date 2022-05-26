using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObstacle : MonoBehaviour
{
    private BoxCollider2D m_collider;

    private bool m_touchMoving;
    private void Awake()
    {
        m_collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //获取第二根手指的手势
        Touch curTouch = Input.GetTouch(1);
        switch (curTouch.phase)
        {
            case TouchPhase.Began:
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(curTouch.position);
                if (m_collider.bounds.Contains(touchPosition))
                    m_touchMoving = true;
                break;
            case TouchPhase.Moved:
                transform.Translate(curTouch.deltaPosition);
                break;
            case TouchPhase.Stationary:
                break;
            case TouchPhase.Ended:
                m_touchMoving = false;
                break;
            case TouchPhase.Canceled:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MessageBall ball = collision.GetComponent<MessageBall>();
        if (ball)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Check to Win");
    }
}
