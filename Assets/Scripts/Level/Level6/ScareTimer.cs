using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScareTimer : MonoBehaviour
{
    [TextArea]
    public string deadText;
    public float clamDistance;
    public GameObject model;
    public Text text;

    private float m_clamTime;

    private bool m_isScaring;
    public bool IsScaring
    {
        get
        {
            return m_isScaring;
        }
    }

    private void Awake()
    {
        Clam();
    }

    void Update()
    {
        if (m_isScaring)
        {

            if (Time.time >= m_clamTime)
                Boom();
            else
                text.text = Mathf.CeilToInt(m_clamTime - Time.time).ToString();
        }
    }

    public void Scare()
    {
        m_clamTime = Time.time + 5.0f;
        m_isScaring = true;
        model.SetActive(true);
        text.gameObject.SetActive(true);
    }

    public void Clam()
    {
        m_isScaring = false;
        model.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void Boom()
    {
        if (deadText.Length > 0)
            UI_InGame.Instance.SetDeadText(deadText);
        else
            UI_InGame.Instance.SetDeadText("不会吧不会吧，这也有人过不了？");


        EventManager.Instance.Trigger("PlayerDead");

        Debug.Log("玩蛋");
        Clam();
    }
}
