using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class ShakePerfomer : MonoBehaviour
{
    [SerializeField] CameraEffects cameraEffects;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    [SerializeField] float shakeTime = 0.20f;

    private void Awake()
    {
        cinemachineBasicMultiChannelPerlin = 
        GetComponent<CinemachineVirtualCamera>().
        GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        SubscribeToCameraEffects();
    }

    private void OnDestroy() => UnsubscribeToCameraEffects();

    void SubscribeToCameraEffects() => cameraEffects.ShakeEvent.AddListener(Shake);
    void UnsubscribeToCameraEffects() => cameraEffects.ShakeEvent.RemoveListener(Shake);

    void Shake(float shakeValue) => StartCoroutine(ShakeRoutine(shakeValue));

    IEnumerator ShakeRoutine(float shakeValue)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeValue;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = shakeValue;

        yield return new WaitForSecondsRealtime(shakeTime);

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
    }
        
}
