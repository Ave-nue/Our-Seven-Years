using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    public int blockIndex;
    public GameObject block;
    public CheckBoard board;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerBase>();
        if (player)
            Check4Block();
    }

    public void Check4Block()
    {
        if (GameManager.Instance.GetBlock(blockIndex))
        {
            block.SetActive(true);
            board?.Pass();
        }
    }
}
