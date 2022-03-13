using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool isInitialPoint = false;
    public static SavePoint CurSavePoint;

    void Start()
    {
        if (isInitialPoint)
            CurSavePoint = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
            TurnOn();
    }

    public void Revive(PlayerBase player)
    {
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
