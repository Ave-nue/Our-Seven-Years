using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCooker : Cooker
{
    protected override void UpdateMove()
    {
        float moveDirH = 0f;
        if (Input.GetKey(KeyCode.A))
            moveDirH += -1f;
        if (Input.GetKey(KeyCode.D))
            moveDirH += 1f;
        MoveH(moveDirH);
        float moveDirV = 0f;
        if (Input.GetKey(KeyCode.W))
            moveDirV += 1f;
        if (Input.GetKey(KeyCode.S))
            moveDirV += -1f;
        MoveV(moveDirV);
    }
}
