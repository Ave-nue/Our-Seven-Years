using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCooker : Cooker
{
    private void Awake()
    {
        EventManager.Instance.AddListener("PlayerController_Left_Down_Girl", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Left_Up_Girl", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Down_Girl", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Up_Girl", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Up_Down_Girl", GoUp);
        EventManager.Instance.AddListener("PlayerController_Up_Up_Girl", GoDown);
        EventManager.Instance.AddListener("PlayerController_Down_Down_Girl", GoDown);
        EventManager.Instance.AddListener("PlayerController_Down_Up_Girl", GoUp);
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerController_Left_Down_Girl", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Left_Up_Girl", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Down_Girl", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Up_Girl", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Up_Down_Girl", GoUp);
        EventManager.Instance.SubListener("PlayerController_Up_Up_Girl", GoDown);
        EventManager.Instance.SubListener("PlayerController_Down_Down_Girl", GoDown);
        EventManager.Instance.SubListener("PlayerController_Down_Up_Girl", GoUp);
    }

    protected override void UpdateMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            GoLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            GoRight();
        MoveH(m_moveDirH);
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            GoUp();
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
            GoDown();
        MoveV(m_moveDirV);
    }
}
