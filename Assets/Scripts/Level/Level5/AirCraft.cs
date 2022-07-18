using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraft : MonoBehaviour
{
    public GameObject bullet;
    public SpriteRenderer spriteR;
    public Sprite flySprite;

    private int m_curOffset;
    private float m_attackCD;
    private bool m_isFly;

    private void Awake()
    {
        EventManager.Instance.AddListener("PlayerController_Left_Down", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Right_Down", GoRight);
    }

    void Start()
    {
        //Fly();
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerController_Left_Down", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Right_Down", GoRight);
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

    public void GoLeft()
    {
        Move(-1);
    }

    public void GoRight()
    {
        Move(1);
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

        if (m_isFly)
        {
            Instantiate(bullet, transform.position + Vector3.left, Quaternion.identity);
            Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    public void Fly()
    {
        m_isFly = true;
        spriteR.sprite = flySprite;
    }
}
