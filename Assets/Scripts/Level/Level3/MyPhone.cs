using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhone : MonoBehaviour
{
    public MessageBall ball;

    private float m_lastY;
    private float m_curVV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void Move(Vector2 targetPos)
    {
        if (ball && !ball.IsActive)
            ball.Active();

        Vector2 newPos = transform.position;
        newPos.y = targetPos.y;
        transform.SetPositionAndRotation(newPos, Quaternion.identity);

        m_curVV = (transform.position.y - m_lastY) / Time.deltaTime;
        m_lastY = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MessageBall ball = collision.collider.GetComponent<MessageBall>();
        if (ball)
        {
            ball.Reflect(1, m_curVV);
        }
    }
}
