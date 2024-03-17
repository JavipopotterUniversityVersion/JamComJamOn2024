using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProcessor : MonoBehaviour
{
    AudioSource source;
    public AudioPlayer ID;
    float time = 0;
    [SerializeField] float duration = 5;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void DistortSound()
    {
        StartCoroutine(Distort());
    }

    IEnumerator Distort()
    {
        while(time < duration)
        {
            time += 0.2f;
            source.pitch = Random.Range(0.75f, 1.25f);
            yield return new WaitForSeconds(0.2f);
        }

        source.pitch = 1;
    }
}
