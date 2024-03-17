using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ScaleFlash : MonoBehaviour
{
    [SerializeField] float scaleDuration = 0.1f;
    [SerializeField] float backDuration = 0.1f;
    TextMeshProUGUI text;
    [SerializeField] float initMult;
    float mult;
    float fontSize;

    private void Awake() 
    {
        text = GetComponent<TextMeshProUGUI>();
        fontSize = text.fontSize;
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

        float multMultult = initMult / (value * 0.5f);
        mult = initMult * value * multMultult;

        while(time <= scaleDuration)
        {
            time += Time.fixedDeltaTime;
            text.fontSize = Mathf.Lerp(fontSize, fontSize * mult, time / scaleDuration);
            yield return new WaitForFixedUpdate();
        }

        time = 0;
        while(time <= backDuration)
        {
            time += Time.fixedDeltaTime;
            text.fontSize = Mathf.Lerp(fontSize * mult, fontSize, time / backDuration);
            yield return new WaitForFixedUpdate();
        }
    }
}
