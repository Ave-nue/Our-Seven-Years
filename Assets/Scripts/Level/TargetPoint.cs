using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TargetPoint : MonoBehaviour
{
    public string nextLevel;
    public UnityEvent todo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������");
        //SceneManager.LoadScene(nextLevel);
        EventManager.Instance.Trigger("PassLevel");
        todo?.Invoke();
    }
}
