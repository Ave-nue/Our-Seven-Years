using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    public List<GameObject> inActiveObjects;
    public List<GameObject> outActiveObjects;

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
        foreach (var item in inActiveObjects)
            item.SetActive(bActive);

        foreach (var item in outActiveObjects)
            item.SetActive(!bActive);
    }
}
