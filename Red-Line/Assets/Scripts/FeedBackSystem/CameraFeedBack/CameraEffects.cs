using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CameraEffects", menuName = "FeedBack/CameraEffects", order = 1)]
public class CameraEffects : ScriptableObject
{
    UnityEvent<float> shakeEvent = new UnityEvent<float>();
    public UnityEvent<float> ShakeEvent => shakeEvent;

    UnityEvent<float> onHitStop = new UnityEvent<float>();
    public UnityEvent<float> OnHitStop => onHitStop;

    UnityEvent<Shader> onShaderChange = new UnityEvent<Shader>();
    public UnityEvent<Shader> OnShaderChange => onShaderChange;
    
    public void Shake(float shakeValue) => shakeEvent.Invoke(shakeValue);
    public void HitStop(float hitStopValue) => onHitStop.Invoke(hitStopValue);
    public void GlobalShaderChange(Shader shader) => onShaderChange.Invoke(shader);
}
