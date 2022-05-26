using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    static private EventManager m_instance;
    static public EventManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new EventManager();
            return m_instance;
        }
    }

    private Dictionary<string, Action> m_listeners;

    public EventManager()
    {
        m_listeners = new Dictionary<string, Action>();
    }

    public void Trigger(string eventName)
    {
        if (m_listeners.ContainsKey(eventName))
            m_listeners[eventName].Invoke();
    }

    public void AddListener(string eventName, Action todo)
    {
        if (m_listeners.ContainsKey(eventName))
        {
            m_listeners[eventName] += todo;
            return;
        }
        else
            m_listeners.Add(eventName, todo);
    }

    public void SubListener(string eventName, Action todo)
    {
        if (m_listeners.ContainsKey(eventName))
            m_listeners[eventName] -= todo;
    }
}
