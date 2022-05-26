using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraft : MonoBehaviour
{
    public GameObject bullet;

    private int m_curOffset;
    private float m_attackCD;

    void Start()
    {
        
    }

    void Update()
    {
        m_attackCD -= Time.deltaTime;
        if (m_attackCD <= 0)
        {
            Attack();
            m_attackCD = 1;
        }

        //后续应该改成屏幕中的按钮
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1);
        }

        Vector3 curPos = transform.position;
        curPos.x = m_curOffset;
        transform.position = curPos;
    }

    public void Move(int offset)
    {
        m_curOffset += offset;
        if (m_curOffset < -3)
            m_curOffset = -3;
        if (m_curOffset > 3)
            m_curOffset = 3;
    }

    public void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
