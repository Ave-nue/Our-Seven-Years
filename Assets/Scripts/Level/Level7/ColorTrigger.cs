using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public GameObject wallsShow;
    public GameObject wallsHide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerBase player = collision.GetComponent<PlayerBase>();
        if (player)
        {
            SetActive(false);
        }
    }

    public void SetActive(bool bActive)
    {
        wallsShow.SetActive(!bActive);
        wallsHide.SetActive(bActive);
    }
}
