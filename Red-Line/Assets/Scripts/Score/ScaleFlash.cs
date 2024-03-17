using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScaleFlash : MonoBehaviour
{
    int lastValue;
    [SerializeField] float scaleDuration = 0.1f;
    [SerializeField] float backDuration = 0.1f;

    public void Flash(int value)
    {
        if(value > lastValue)
        {
            StopCoroutine(ScaleFlashCorroutine(value));
            StartCoroutine(ScaleFlashCorroutine(value));
            lastValue = value;
        }
    }

    IEnumerator ScaleFlashCorroutine(int value)
    {
        float time = 0;

        while(time <= scaleDuration)
        {
            time += Time.fixedDeltaTime;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * value * 0.12f, time / scaleDuration);
            yield return new WaitForFixedUpdate();
        }

        time = 0;
        while(time <= backDuration)
        {
            time += Time.fixedDeltaTime;
            transform.localScale = Vector3.Lerp(Vector3.one * value * 0.12f, Vector3.one, time / backDuration);
            yield return new WaitForFixedUpdate();
        }

        lastValue = 0;
    }
}
