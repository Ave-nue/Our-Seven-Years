using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGameGrid : MonoBehaviour
{
    public SpriteRenderer sprite;

    static private LinkGameGrid m_curSelectedGrid;

    private Vector2Int m_coor;
    public int X
    {
        get
        {
            return m_coor.x;
        }
    }
    public int Y
    {
        get
        {
            return m_coor.y;
        }
    }

    private int m_sex;//0-Å® 1-ÄÐ
    public int Sex
    {
        get { return m_sex; }
    }

    public void Select()
    {
        Debug.Log(X + ", " + Y);
        if (!m_curSelectedGrid)
        {
            sprite.color = Color.red;
            m_curSelectedGrid = this;
            return;
        }

        if (m_curSelectedGrid == this)
        {
            sprite.color = Color.white;
            m_curSelectedGrid = null;
            return;
        }

        bool isEliminate = LinkGameManager.Instance.Check2Eliminate(m_curSelectedGrid, this);
        if (isEliminate)
        {

            LinkGameGrid girl, boy;
            girl = Sex == 0 ? this : m_curSelectedGrid;
            boy = Sex == 1 ? this : m_curSelectedGrid;
            LinkGameManager.Instance.RemoveOneItem(0, girl);
            LinkGameManager.Instance.RemoveOneItem(1, boy);
            Destroy(m_curSelectedGrid.gameObject);
            Destroy(gameObject);
            m_curSelectedGrid = null;
        }
        else
        {
            m_curSelectedGrid.Select();
        }
    }

    public void SetSprite(int sex, Sprite newIcon)
    {
        m_sex = sex;
        sprite.sprite = newIcon;
    }

    public void SetCoor(Vector2Int coor)
    {
        m_coor = coor;
    }
}
