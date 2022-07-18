using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new GameManager();

            return m_instance;
        }
    }

    GameManager()
    {
        m_blocks = new List<bool>();
        for (int i = 0; i < 4; i++)
            m_blocks.Add(false);
    }

    private List<bool> m_blocks;

    public void SetBlock(int index)
    {
        m_blocks[index] = true;
    }

    public bool HasBlock(int index)
    {
        return m_blocks[index];
    }

    public bool GetBlock(int index)
    {
        bool result = m_blocks[index];
        m_blocks[index] = false;
        return result;
    }
}
