using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    [TextArea]
    public string deadText;
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

            if (deadText.Length > 0)
                UI_InGame.Instance.SetDeadText(deadText);
            else
                UI_InGame.Instance.SetDeadText("不会吧不会吧，这也有人过不了？");
            player.Kill();
        }
    }
}
