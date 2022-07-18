using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTarget : MonoBehaviour
{
    [TextArea]
    public string deadText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pressure pressure = collision.GetComponent<Pressure>();
        if (pressure)
        {
            if (deadText.Length > 0)
                UI_InGame.Instance.SetDeadText(deadText);
            else
                UI_InGame.Instance.SetDeadText("����ɲ���ɣ���Ҳ���˹����ˣ�");


            EventManager.Instance.Trigger("PlayerDead");
            Debug.Log("����");
        }
    }
}
