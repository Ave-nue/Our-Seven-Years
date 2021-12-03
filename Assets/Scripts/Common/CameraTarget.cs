using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    public CinemachineConfiner targetCameraConfiner;

    private Collider2D m_curConfiner;
    private Collider2D[] m_checkCache = new Collider2D[8];

    void Update()
    {
        Physics2D.OverlapPointNonAlloc(transform.position, m_checkCache);
        foreach (var item in m_checkCache)
        {
            if (item == null)
                break;

            if (item.CompareTag("Confiner") && m_curConfiner != item)
                m_curConfiner = item;
        }
        if (m_curConfiner && m_curConfiner != targetCameraConfiner.m_BoundingShape2D)
            targetCameraConfiner.m_BoundingShape2D = m_curConfiner;
    }
}
