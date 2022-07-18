using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool isInitialPoint = false;
    public static SavePoint CurSavePoint;
    public static SavePoint CurSavePoint_Boy;
    public static SavePoint CurSavePoint_Girl;

    void Start()
    {
        if (isInitialPoint)
            CurSavePoint = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            TurnOn();
            if (collision.GetComponent<PlayerBoy>())
                CurSavePoint_Boy = this;
            if (collision.GetComponent<PlayerGirl>())
                CurSavePoint_Girl = this;
        }
    }

    public void Revive(PlayerBase player)
    {
        Debug.Log(player.gameObject.name);
        player.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        player.Revive();
    }

    public void TurnOn()
    {
        CurSavePoint?.TurnOff();
        CurSavePoint = this;
    }

    public void TurnOff()
    {
        if (CurSavePoint == this)
            CurSavePoint = null;
    }
}
