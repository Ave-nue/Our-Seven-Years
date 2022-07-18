using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hormone : MonoBehaviour
{
    private bool m_isFollowing;
    private int m_followingTouchIndex;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            if ((mousePos - transform.position).magnitude < 1)
                m_isFollowing = true;
        }

        if (!m_isFollowing && Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch curTouch = Input.GetTouch(i);
                var touchPos = Camera.main.ScreenToWorldPoint(curTouch.position);
                if ((touchPos - transform.position).magnitude < 1)
                {
                    m_isFollowing = true;
                    m_followingTouchIndex = i;
                }
            }
            
        }

        if (Input.GetMouseButtonUp(0))
            m_isFollowing = false;

        if (m_isFollowing)
        {
            if (m_followingTouchIndex < Input.touchCount && (int)Input.GetTouch(m_followingTouchIndex).phase < 3)
            {
                var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(m_followingTouchIndex).position);
                touchPos.z = 0.0f;
                transform.position = touchPos;
            }
            else
                m_isFollowing = false;

            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AirCraft player = collision.GetComponent<AirCraft>();
        if (player)
        {
            player.Fly();
            Destroy(gameObject);
        }
    }
}
