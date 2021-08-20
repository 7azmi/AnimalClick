using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Sprite Sprite { get { return GameManager.instance.gameSettings.getBackground; } }

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = Sprite;
    }
}
