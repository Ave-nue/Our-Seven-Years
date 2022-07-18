using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareMgr : MonoBehaviour
{
    public int totalScareTimes;
    public float minScareCD;
    public float maxScareCD;
    public List<Transform> players;
    public List<ScareTimer> scares;

    private int m_scaredTimes;
    private float m_nextScareTime;

    private void Awake()
    {
        EventManager.Instance.AddListener("PlayerDead", OnPlayerDead);
        EventManager.Instance.AddListener("PlayerController_Use", Check2Clam);
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerDead", OnPlayerDead);
        EventManager.Instance.SubListener("PlayerController_Use", Check2Clam);
    }

    void Update()
    {
        if (Time.time >= m_nextScareTime)
            Scare();

        if (Input.GetKey(KeyCode.E))
            Check2Clam();
    }

    public void Scare()
    {
        if (m_scaredTimes > totalScareTimes)
        {
            Win();
            return;
        }

        int randScareIndex = Random.Range(0, scares.Count);
        while (scares[randScareIndex].IsScaring)
            randScareIndex = Random.Range(0, scares.Count);
        ScareTimer curScare = scares[randScareIndex];
        curScare.Scare();
        m_nextScareTime = Time.time + Random.Range(minScareCD, maxScareCD);
        m_scaredTimes++;
    }

    public void Check2Clam()
    {
        foreach (var item in scares)
            foreach (var player in players)
                if ((item.transform.position - player.position).magnitude <= item.clamDistance)
                    item.Clam();
    }

    public void OnPlayerDead()
    {
        m_scaredTimes = 0;
    }

    public void Win()
    {
        EventManager.Instance.Trigger("PassLevel");
        Debug.Log("ÎÈ");
        m_scaredTimes = 0;
    }
}
