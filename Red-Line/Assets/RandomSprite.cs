using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] bool randomOnEnable = true;
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        if (randomOnEnable) {
            RandomizeSprite();
        }
    }

    public void RandomizeSprite() 
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
