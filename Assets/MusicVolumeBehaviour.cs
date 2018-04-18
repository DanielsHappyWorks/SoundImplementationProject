using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeBehaviour : MonoBehaviour {
    public AudioClip volumeClip;
    MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            musicManager.SetNextClip(volumeClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            musicManager.SetDefault(volumeClip);
        }
    }
}
