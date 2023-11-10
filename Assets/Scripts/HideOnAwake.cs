using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnAwake : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
}
