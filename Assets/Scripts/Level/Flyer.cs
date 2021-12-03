using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flyer : MonoBehaviour
{
    public Vector2 flyOffset;
    public float duration;

    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Fly()
    {
        m_rigidbody.DOMove(m_rigidbody.position + flyOffset, duration);
    }
}
