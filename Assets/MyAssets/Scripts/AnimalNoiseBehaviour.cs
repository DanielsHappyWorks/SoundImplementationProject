using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNoiseBehaviour : MonoBehaviour {
    public AudioClip[] noises;
    private AudioSource audioSource;
    public float minTime, maxTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayNoise", Random.Range(minTime, maxTime));
    }

    void PlayNoise()
    {
        audioSource.clip = noises[(int)Random.Range(0, noises.Length)];
        audioSource.pitch = (Random.Range(0.9f, 1.1f));
        audioSource.volume = (Random.Range(0.2f, 0.9f));
        audioSource.Play();
        Invoke("PlayNoise", Random.Range(minTime, maxTime));
    }
}
