using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BlockGiver : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetBlock(3);
    }
}
