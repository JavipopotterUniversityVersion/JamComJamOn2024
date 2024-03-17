using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignettePerformer : MonoBehaviour
{
    float minVignette = 0;
    float maxVignette = 0.3f;

    [SerializeField] float intervalIn;
    [SerializeField] float intervalOut;
    [SerializeField] VolumeProfile volume;
    Vignette vignette;

    [SerializeField] LifeContainer lifeContainer;

    bool isVignetteIn = true;

    float timer = 0;

    [SerializeField] VignetteData[] vignetteDatas;

    private void Awake() {
        volume.TryGet(out Vignette vignette);
        this.vignette = vignette;

        vignette.intensity.value = 0;

        lifeContainer.OnLivesChange.AddListener(OnLifeChange);
    }

    void OnLifeChange(int life)
    {
        if(life >= vignetteDatas.Length || life < 0) return;

        minVignette = vignetteDatas[life].minVignette;
        maxVignette = vignetteDatas[life].maxVignette;
        intervalIn = vignetteDatas[life].intervalIn;
        intervalOut = vignetteDatas[life].intervalOut;
    }

    private void Update() 
    {
        if(intervalIn == 0 || intervalOut == 0) return;

        timer += Time.deltaTime;

        if(timer > (isVignetteIn ? intervalIn : intervalOut))
        {
            timer = 0;
            isVignetteIn = !isVignetteIn;
        }

        if(isVignetteIn)
        {
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, maxVignette, timer / intervalIn);
        }
        else
        {
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, minVignette, timer / intervalOut);
        }
    }

    private void OnDestroy() {
        lifeContainer.OnLivesChange.RemoveListener(OnLifeChange);
    
    }
}

[System.Serializable]
public class VignetteData
{
    public float minVignette = 0;
    public float maxVignette = 0.3f;

    public float intervalIn;
    public float intervalOut;
}