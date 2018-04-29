using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntBehaviour : MonoBehaviour {
    public AudioClip[] noises;
    private AudioSource audioSource;
    private int noiseCounter;
    public float minTime, maxTime;
    public float pitch;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        noiseCounter = (int)Random.Range(0, noises.Length);
        Invoke("PlayNoise", Random.Range(minTime, maxTime));
    }

    void PlayNoise()
    {
        noiseCounter++;
        if (noiseCounter == noises.Length)
        {
            noiseCounter = 0;
        }

        audioSource.clip = noises[noiseCounter];
        audioSource.pitch = (pitch);
        audioSource.volume = (Random.Range(0.7f, 1f));
        audioSource.Play();
        Invoke("PlayNoise", Random.Range(minTime, maxTime));
    }
}
