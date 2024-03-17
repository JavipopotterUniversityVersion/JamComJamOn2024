using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuActivator : MonoBehaviour
{
    [SerializeField] GlobalStateManager _globalStateManager;

    private void Awake() {
        _globalStateManager.OnDeathEvent.AddListener(() => gameObject.SetActive(true));
        _globalStateManager.OnResume.AddListener(() => gameObject.SetActive(false));
    }

    private void OnDestroy() {
        _globalStateManager.OnDeathEvent.RemoveListener(() => gameObject.SetActive(true));
        _globalStateManager.OnResume.RemoveListener(() => gameObject.SetActive(false));
    }
}
