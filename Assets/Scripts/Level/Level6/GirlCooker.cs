using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCooker : Cooker
{
    protected override void UpdateMove()
    {
        float moveDirH = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirH += -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirH += 1f;
        MoveH(moveDirH);
        float moveDirV = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirV += 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirV += -1f;
        MoveV(moveDirV);
    }
}
