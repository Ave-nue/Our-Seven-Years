using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BG : MonoBehaviour
{
    public SpriteRenderer bg;
    public Transform player;
    public float targetX;

    private float m_initialAlpha;

    // Start is called before the first frame update
    void Start()
    {
        m_initialAlpha = bg.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        bg.color = new Color(bg.color.r, bg.color.g, bg.color.b, m_initialAlpha + (1 - m_initialAlpha) * (player.position.x / targetX));
    }
}
