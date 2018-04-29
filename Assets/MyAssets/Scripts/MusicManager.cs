using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioClip currentClip;
    public AudioClip nextClip;
    public AudioClip defaultClip;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(nextClip.name != currentClip.name)
        {
            currentClip = nextClip;
            audioSource.clip = currentClip;
        }

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
	}

    public void SetNextClip(AudioClip ac)
    {
        nextClip = ac;
    }

    public void SetDefault(AudioClip ac)
    {
        if (ac.name == currentClip.name)
        {
            nextClip = defaultClip;
        }
    }
}
