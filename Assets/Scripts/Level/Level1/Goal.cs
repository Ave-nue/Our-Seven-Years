using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : PhysicsBase
{
    public GameObject coach;
    public GameObject goalkeeper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Soccer soccer = collision.GetComponent<Soccer>();
        if (soccer)
        {
            coach?.SetActive(false);
            goalkeeper?.SetActive(false);
            //Debug.Log("½øÇòÀ²£¡");
        }
    }
}
