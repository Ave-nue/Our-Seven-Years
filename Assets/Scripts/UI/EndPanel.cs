using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    public float minCD;
    public float maxCD;
    public float minSize;
    public float maxSize;
    public GameObject picturePfb;

    private float m_nextTime;
    private List<EndPanelPicture> m_showingPics;

    private void Awake()
    {
        m_showingPics = new List<EndPanelPicture>();
        m_nextTime = Time.time;
    }

    private void Update()
    {
        if (Time.time >= m_nextTime)
        {

        }
    }

    public void AddPicture()
    {

    }
}
