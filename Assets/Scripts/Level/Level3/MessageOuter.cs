using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOuter : MonoBehaviour
{
    [TextArea]
    public string deadText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var msg = collision.GetComponent<MessageBall>();
        if (msg)
        {
            if (deadText.Length > 0)
                UI_InGame.Instance.SetDeadText(deadText);
            else
                UI_InGame.Instance.SetDeadText("����ɲ���ɣ���Ҳ���˹����ˣ�");


            EventManager.Instance.Trigger("PlayerDead");
        }
    }
}
