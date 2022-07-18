using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_InGame : MonoBehaviour
{
    public GameObject panelSetting;
    public GameObject panelWin;
    public GameObject panelFail;

    public Text txtDead;

    private int m_showingPanel = 0;

    private static UI_InGame m_instance;
    public static UI_InGame Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        EventManager.Instance.AddListener("PlayerDead", OnPlayerDead);
        EventManager.Instance.AddListener("PassLevel", OnPlayerWin);

        m_instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerDead", OnPlayerDead);
        EventManager.Instance.SubListener("PassLevel", OnPlayerWin);
        Time.timeScale = 1f;
    }

    public void RefreshUI()
    {
        Time.timeScale = (m_showingPanel == 0 ? 1f : 0f);
        panelSetting.SetActive(m_showingPanel == 1);
        panelWin.SetActive(m_showingPanel == 2);
        panelFail.SetActive(m_showingPanel == 3);
    }

    public void Back2Home()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoOn()
    {
        m_showingPanel = 0;
        RefreshUI();
    }

    public void Pause()
    {
        m_showingPanel = 1;
        RefreshUI();
    }

    public void OnPlayerWin()
    {
        ES3.Save<int>("passLevel", SceneManager.GetActiveScene().buildIndex);

        m_showingPanel = 2;
        RefreshUI();
    }

    public void SetDeadText(string text)
    {
        txtDead.text = text;
    }

    public void OnPlayerDead()
    {
        m_showingPanel = 3;
        RefreshUI();
    }
}
