using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int duration = 30;
    public bool startStart = false;
    public Text text;
    [TextArea]
    public string deadText;

    private float m_remainTime;
    void Start()
    {
        if (startStart)
            StartTime();
    }

    void Update()
    {
        if (m_remainTime > 0)
            UpdateTime();
    }

    public void StartTime()
    {
        m_remainTime = duration;
    }

    public void StopTime()
    {
        m_remainTime = 0f;
    }

    public void UpdateTime()
    {
        m_remainTime -= Time.deltaTime;
        text.text = Mathf.CeilToInt(m_remainTime).ToString();
        if (m_remainTime <= 0)
            OnFinish();
    }

    public void OnFinish()
    {
        if (deadText.Length > 0)
            UI_InGame.Instance.SetDeadText(deadText);
        else
            UI_InGame.Instance.SetDeadText("不会吧不会吧，这也有人过不了？");


        EventManager.Instance.Trigger("PlayerDead");
        Debug.Log("游戏结束");
    }
}
