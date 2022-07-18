using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    public Image imgLevel;
    public Image imgLock;
    public GameObject panelChangeLevel;
    public List<Sprite> levelSprites;

    private int m_curLevelIndex;

    private void Start()
    {
        if (!ES3.KeyExists("passLevel"))
            ES3.Save<int>("passLevel", 0);

        RefreshUI();
    }

    public void RefreshUI()
    {
        imgLevel.sprite = levelSprites[m_curLevelIndex];
        imgLevel.color = new Color(1f, 1f, 1f, IsLocked(m_curLevelIndex) ? 0.2578125f : 1f);
        imgLock.gameObject.SetActive(IsLocked(m_curLevelIndex));
        panelChangeLevel.SetActive(m_curLevelIndex > 0);
    }

    public void StartGame()
    {
        if (m_curLevelIndex == 0)
        {
            m_curLevelIndex = 1;
            RefreshUI();
        }
        else
        {
            SceneManager.LoadScene(m_curLevelIndex);
        }
    }

    public void QuitGame()
    {
        if (m_curLevelIndex != 0)
        {
            m_curLevelIndex = 0;
            RefreshUI();
        }
        else
        {
            Application.Quit();
        }
    }

    public void ChangeLevel(int offset)
    {
        m_curLevelIndex = (m_curLevelIndex + offset + 6) % 7 + 1;
        RefreshUI();
    }

    public bool IsLocked(int levelIndex)
    {
        if (levelIndex > 1)
            return ES3.Load<int>("passLevel") + 1 < levelIndex;
        return false;
    }
}
