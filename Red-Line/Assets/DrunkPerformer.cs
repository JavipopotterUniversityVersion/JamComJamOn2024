using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DrunkPerformer : MonoBehaviour
{
    [SerializeField] CameraEffects _cameraEffects;
    [SerializeField] VolumeProfile _volumeProfile;
    ColorAdjustments _colorAdjustments;
    LensDistortion _lensDistortion;

    private void Awake() 
    {
        _volumeProfile.TryGet(out ColorAdjustments colorAdjustments);
        _colorAdjustments = colorAdjustments;

        _volumeProfile.TryGet(out LensDistortion lensDistortion);
        _lensDistortion = lensDistortion;

        _cameraEffects.OnDrunkEffect.AddListener((float duration) => StartCoroutine(DrunkEffect(duration)));
    }

    void Start() 
    {
        _colorAdjustments.active = false;
        _lensDistortion.active = false;
    }

    void OnDestroy()
    {
        _cameraEffects.OnDrunkEffect.RemoveListener((float duration) => StartCoroutine(DrunkEffect(duration)));
        
        _colorAdjustments.active = false;
        _lensDistortion.active = false;
    }

    IEnumerator DrunkEffect(float duration)
    {
        _colorAdjustments.active = true;
        _lensDistortion.active = true;
        yield return new WaitForSeconds(duration);
        _colorAdjustments.active = false;
        _lensDistortion.active = false;
    }
}
