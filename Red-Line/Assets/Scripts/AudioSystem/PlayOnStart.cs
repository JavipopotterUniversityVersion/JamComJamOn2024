using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    [SerializeField] AudioPlayer audioPlayer;
    
    private void Start() => audioPlayer.Play();
}
