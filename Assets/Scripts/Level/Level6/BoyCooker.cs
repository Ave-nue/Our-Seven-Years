using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyCooker : Cooker
{
    private void Awake()
    {
        EventManager.Instance.AddListener("PlayerController_Left_Down_Boy", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Left_Up_Boy", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Down_Boy", GoRight);
        EventManager.Instance.AddListener("PlayerController_Right_Up_Boy", GoLeft);
        EventManager.Instance.AddListener("PlayerController_Up_Down_Boy", GoUp);
        EventManager.Instance.AddListener("PlayerController_Up_Up_Boy", GoDown);
        EventManager.Instance.AddListener("PlayerController_Down_Down_Boy", GoDown);
        EventManager.Instance.AddListener("PlayerController_Down_Up_Boy", GoUp);
    }

    private void OnDestroy()
    {
        EventManager.Instance.SubListener("PlayerController_Left_Down_Boy", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Left_Up_Boy", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Down_Boy", GoRight);
        EventManager.Instance.SubListener("PlayerController_Right_Up_Boy", GoLeft);
        EventManager.Instance.SubListener("PlayerController_Up_Down_Boy", GoUp);
        EventManager.Instance.SubListener("PlayerController_Up_Up_Boy", GoDown);
        EventManager.Instance.SubListener("PlayerController_Down_Down_Boy", GoDown);
        EventManager.Instance.SubListener("PlayerController_Down_Up_Boy", GoUp);
    }

    protected override void UpdateMove()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            GoLeft();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            GoRight();
        MoveH(m_moveDirH);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            GoUp();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            GoDown();
        MoveV(m_moveDirV);
    }
}
