using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flyer : MonoBehaviour
{
    public Vector2 flyOffset;
    public float duration;

    private Rigidbody2D m_rigidbody;
    private Vector3 m_initialPosition;
    private Quaternion m_initialRotation;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_initialPosition = transform.position;
        m_initialRotation = transform.rotation;
        EventManager.Instance.AddListener("PlayerRevive", Restore);
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerRevive", Restore);
    }

    public void Fly()
    {
        m_rigidbody.DOMove(m_rigidbody.position + flyOffset, duration);
    }

    public void Restore()
    {
        m_rigidbody.DOKill(false);
        transform.SetPositionAndRotation(m_initialPosition, m_initialRotation);
    }
}
