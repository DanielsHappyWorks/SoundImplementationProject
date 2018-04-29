using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRingBehaviour : MonoBehaviour {
    private AudioSource audioSource;
    public float minTime, maxTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("RingKey", Random.Range(minTime, maxTime));
    }

    void RingKey()
    {
        audioSource.pitch = (Random.Range(1.1f, 1.15f));
        audioSource.volume = (Random.Range(0.5f, 0.8f));
        audioSource.Play();
        Invoke("RingKey", Random.Range(minTime, maxTime));
    }
}
