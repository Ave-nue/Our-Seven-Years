using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockList : MonoBehaviour
{
    public List<GameObject> uiItems = new List<GameObject>();

    void Update()
    {
        for (int i = 0; i < uiItems.Count; i++)
        {
            uiItems[i].SetActive(GameManager.Instance.HasBlock(i));
        }
    }
}
