using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildrenSprites : MonoBehaviour
{
    SpriteRenderer[] childrenSprites;
    [SerializeField] Sprite[] sprites;

    SpriteMask spriteMask;

    private void Awake() 
    {
        childrenSprites = GetComponentsInChildren<SpriteRenderer>();
        spriteMask = GetComponentInChildren<SpriteMask>();
    }

    private void OnEnable() 
    {
        RandomizeSprites();
    }

    public void RandomizeSprites() 
    {
        int randomSortOrder = Random.Range(-100, 0);
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];

        foreach (SpriteRenderer sprite in childrenSprites)
        {
            sprite.sprite = randomSprite;
            sprite.sortingOrder = randomSortOrder;
        }

        foreach (SpriteMask mask in GetComponentsInChildren<SpriteMask>())
        {
            mask.sprite = randomSprite;
        }
    }
}
