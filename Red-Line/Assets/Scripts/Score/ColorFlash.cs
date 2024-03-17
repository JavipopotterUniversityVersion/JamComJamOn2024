using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class ColorFlash : MonoBehaviour
{
    [SerializeField] Gradient colorGradient;

    [SerializeField] float FlashDuration = 0.1f;
    [SerializeField] float backDuration = 0.1f;

    TextMeshProUGUI text;

    private void Awake() 
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Flash(int value)
    {
        if(value < 9) return;

        StopCoroutine(ScaleFlashCorroutine(value));
        StartCoroutine(ScaleFlashCorroutine(value));
    }

    IEnumerator ScaleFlashCorroutine(int value)
    {
        float time = 0;

        while(time <= FlashDuration)
        {
            time += Time.fixedDeltaTime;
            text.color = colorGradient.Evaluate(time / FlashDuration * value * 0.01f);
            yield return new WaitForFixedUpdate();
        }

        time = 0;
        
        while(time <= backDuration)
        {
            time += Time.fixedDeltaTime;
            text.color = UnityEngine.Color.Lerp(text.color, UnityEngine.Color.white, time / backDuration);
            yield return new WaitForFixedUpdate();
        }
    }
}
