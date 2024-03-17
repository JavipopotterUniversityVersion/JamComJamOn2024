using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUI : MonoBehaviour
{
    [SerializeField] private LifeContainer _lifeContainer;
    [SerializeField] private Image _image;
    [SerializeField] private int _nHeart;

    private void Update()
    {
        if (_lifeContainer.Lives < _nHeart) _image.enabled = false;
        else _image.enabled = true;
    }
}
