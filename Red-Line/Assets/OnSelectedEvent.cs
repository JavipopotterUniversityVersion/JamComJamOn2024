using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSelectedEvent : MonoBehaviour
{
    Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    void OnSelected()
    {
        print("Selected");
    }
}
