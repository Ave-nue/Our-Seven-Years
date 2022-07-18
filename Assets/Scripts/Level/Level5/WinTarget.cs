using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTarget : MonoBehaviour
{
    public float speed = 0;
    public string nextLevel;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AirCraft player = collision.GetComponent<AirCraft>();
        if (player)
        {
            EventManager.Instance.Trigger("PassLevel");
            Debug.Log("¹ý¹ØÀ²£¡");
            //SceneManager.LoadScene(nextLevel);
        }
    }
}
