using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite attackSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            if (attackSprite)
            {
                if (!render)
                    render = GetComponent<SpriteRenderer>();
                render.sprite = attackSprite;
            }
            player.Kill();
        }
    }
}
