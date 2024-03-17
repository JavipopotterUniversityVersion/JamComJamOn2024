using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DamageEffectPerformer : MonoBehaviour
{
    [SerializeField] VolumeProfile _volumeProfile;
    [SerializeField] CameraEffects _cameraEffects;
    ChannelMixer _channelMixer;
    FilmGrain _filmGrain;

    private void Awake() {
        _volumeProfile.TryGet(out ChannelMixer channelMixer);
        _channelMixer = channelMixer;

        _volumeProfile.TryGet(out FilmGrain filmGrain);
        _filmGrain = filmGrain;

        _cameraEffects.OnHit.AddListener((float duration) => StartCoroutine(HitEffect(duration)));
    }

    IEnumerator HitEffect(float duration)
    {
        _channelMixer.active = true;
        _filmGrain.active = true;
        yield return new WaitForSeconds(duration);
        _channelMixer.active = false;
        _filmGrain.active = false;
    }

    private void Start() {
        _channelMixer.active = false;
        _filmGrain.active = false;
    }

    private void OnDestroy() {
        _cameraEffects.OnHit.RemoveListener((float duration) => StartCoroutine(HitEffect(duration)));
        
        _channelMixer.active = false;
        _filmGrain.active = false;
    }
}
