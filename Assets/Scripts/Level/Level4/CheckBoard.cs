using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoard : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite passSprite;

    public void Pass()
    {
        spriteR.sprite = passSprite;
    }
}
