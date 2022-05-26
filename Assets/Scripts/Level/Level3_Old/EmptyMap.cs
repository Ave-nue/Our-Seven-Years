using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyMap
{
    private int m_size;
    private List<List<Vector2Int>> m_data;

    EmptyMap(int size)
    {
        m_size = size;
        m_data = new List<List<Vector2Int>>(m_size);
    }

    public void Remove(int x, int y)
    {
        if (x < 0 || x >= m_size)
            return;
        if (y < 0 || y >= m_size)
            return;

        int insertIndex = 0;
        for (insertIndex = 0; insertIndex < m_data[x].Count; insertIndex++)
        {
            if (m_data[x][insertIndex].x == y)
                return;
            if (m_data[x][insertIndex].x > y)
                break;
        }

        if (m_data[x][insertIndex].x == y + 1)
        {
            Vector2Int range = m_data[x][insertIndex];
            range.x = y;
            m_data[x][insertIndex] = range;

            if (insertIndex > 0 && m_data[x][insertIndex - 1].y == y - 1)
            {
                range.x = m_data[x][insertIndex - 1].x;
                m_data[x][insertIndex - 1] = range;
                m_data[x].RemoveAt(insertIndex);
            }
            return;
        }

        if (insertIndex > 0 && m_data[x][insertIndex - 1].y == y - 1)
        {
            Vector2Int range = m_data[x][insertIndex - 1];
            range.y = y;
            m_data[x][insertIndex - 1] = range;
            return;
        }

        m_data[x].Insert(insertIndex, new Vector2Int(y, y));
    }

    public void Insert(int x, int y)
    {
        if (x < 0 || x >= m_size)
            return;
        if (y < 0 || y >= m_size)
            return;

        int insertIndex = 0;
        for (insertIndex = 0; insertIndex < m_data[x].Count; insertIndex++)
        {
            if (m_data[x][insertIndex].x == y)
            {
                if (m_data[x][insertIndex].x == m_data[x][insertIndex].y)
                {
                    m_data[x].RemoveAt(insertIndex);
                }
                else
                {
                    Vector2Int range = m_data[x][insertIndex];
                    range.x = y + 1;
                    m_data[x][insertIndex] = range;
                }
                return;
            }
            if (m_data[x][insertIndex].x > y)
                break;
        }

        insertIndex--;
        if (insertIndex < 0)
            return;

        if (m_data[x][insertIndex].y == y)
        {
            Vector2Int range = m_data[x][insertIndex];
            range.y = y - 1;
            m_data[x][insertIndex] = range;
        }
        else if (m_data[x][insertIndex].y > y)
        {
            Vector2Int range = m_data[x][insertIndex];
            range.x = y + 1;
            m_data[x].Insert(insertIndex + 1, range);
            range = m_data[x][insertIndex];
            range.y = y - 1;
            m_data[x][insertIndex] = range;
        }
    }

    public void GetXDelta(int x, int y, out int minY, out int maxY)
    {
        minY = y;
        maxY = y;

        if (x < 0 || x >= m_size)
            return;
        if (y < 0 || y >= m_size)
            return;

        int insertIndex = 0;
        for (insertIndex = 0; insertIndex < m_data[x].Count; insertIndex++)
        {
            if (m_data[x][insertIndex].x == y)
            {
                minY = m_data[x][insertIndex].x;
                maxY = m_data[x][insertIndex].y;
                return;
            }
            if (m_data[x][insertIndex].x > y)
                break;
        }

        insertIndex--;
        if (insertIndex < 0)
            return;

        if (m_data[x][insertIndex].y < y)
            return;

        minY = m_data[x][insertIndex].x;
        maxY = m_data[x][insertIndex].y;
    }
}
