using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildrenSprites : MonoBehaviour
{
    SpriteRenderer[] childrenSprites;
    [SerializeField] Sprite[] sprites;

    private void Awake() 
    {
        childrenSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        RandomizeSprites();
    }

    public void RandomizeSprites() 
    {
        foreach (SpriteRenderer sprite in childrenSprites)
        {
            sprite.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
