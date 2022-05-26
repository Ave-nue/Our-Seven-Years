using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHolder : MonoBehaviour
{
    public List<string> restoreEvents;

    private Vector3 m_initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_initialPosition = transform.position;
        foreach (var curEvent in restoreEvents)
            EventManager.Instance.AddListener(curEvent, Restore);
    }

    private void OnDestroy()
    {
        foreach (var curEvent in restoreEvents)
            EventManager.Instance.SubListener(curEvent, Restore);
    }

    public void Restore()
    {
        transform.SetPositionAndRotation(m_initialPosition, Quaternion.identity);
    }
}
