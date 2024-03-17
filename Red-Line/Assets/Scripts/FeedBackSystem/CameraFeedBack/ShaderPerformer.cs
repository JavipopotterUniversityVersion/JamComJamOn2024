using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPerformer : MonoBehaviour
{
    [SerializeField] CameraEffects cameraEffects;
    [SerializeField] float duration;

    private void Awake() 
    {
        cameraEffects.OnShaderChange.AddListener(ChangeGlobalShader);
    }

    private void OnDestroy() 
    {
        cameraEffects.OnShaderChange.RemoveListener(ChangeGlobalShader);
    }

    void ChangeGlobalShader(Shader shader)
    {
        StartCoroutine(ChangeShader(shader));
    }

    IEnumerator ChangeShader(Shader shader)
    {
        print("Changing shader");
        Camera.main.SetReplacementShader(shader, "RenderType");
        yield return new WaitForSeconds(duration);
        Camera.main.ResetReplacementShader();
    }
}
