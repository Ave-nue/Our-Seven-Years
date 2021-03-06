using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public int triggerCount = 1;
    public UnityEvent todo;

    private int m_usedCount;

    void Start()
    {
        EventManager.Instance.AddListener("PlayerRevive", Restore);
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerRevive", Restore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        if (m_usedCount >= triggerCount)
            return;

        todo.Invoke();

        m_usedCount++;
    }

    public void Restore()
    {
        m_usedCount = 0;
    }
}
