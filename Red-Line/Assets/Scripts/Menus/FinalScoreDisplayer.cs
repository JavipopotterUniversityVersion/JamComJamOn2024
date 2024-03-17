using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Score _score;

    public void UpdateDeathText()
    {
        text.text = _score.score.ToString();
    }
}
