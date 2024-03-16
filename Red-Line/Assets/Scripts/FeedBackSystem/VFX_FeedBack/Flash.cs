using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float flashTime = 0.1f;
    Material defaultMaterial;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        defaultMaterial = GetComponentInChildren<SpriteRenderer>().material;
    }

    public void FlashEffect()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.material = material;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = defaultMaterial;
    }
}
