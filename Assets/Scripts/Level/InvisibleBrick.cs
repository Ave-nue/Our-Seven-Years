using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InvisibleBrickType
{
    bottom = 0,
    not_up,
}

public class InvisibleBrick : MonoBehaviour
{
    public InvisibleBrickType type;
    public GameObject brick;

    private void Awake()
    {
        brick.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            if (ShouldShow(player))
            {
                ShowBrick();
            }
        }
    }

    private bool ShouldShow(PlayerBase player)
    {
        Vector2 dis = transform.position - player.transform.position;
        switch (type)
        {
            case InvisibleBrickType.bottom:
                return dis.y > Mathf.Abs(dis.x);
            case InvisibleBrickType.not_up:
                return dis.y < dis.x;
            default:
                return false;
        }
    }

    public void ShowBrick()
    {
        brick.SetActive(true);
    }
}
