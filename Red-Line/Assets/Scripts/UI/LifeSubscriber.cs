using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSubscriber : MonoBehaviour
{
    HealthComponent healthComponent;
    [SerializeField] LifeContainer lifeContainer;

    private void Awake() {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnLifeChanged.AddListener(lifeContainer.SetLives);
    }
}
