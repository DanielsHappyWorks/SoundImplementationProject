using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NPCDialogBehaviour : MonoBehaviour {
    public AudioClip[] introDialog;
    public AudioClip[] keysDialog;
    public AudioClip[] completedDialog;

    private RigidbodyFirstPersonController playerController;
    private AudioSource audioSource;
    private bool isPlayerNear;
    private int audioClipCounter;
    private bool introCompleted;
    private bool keysCompleted;

    // Use this for initialization
    void Start () {
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
        isPlayerNear = false;
        introCompleted = false;
        keysCompleted = false;
        audioClipCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Stop();

            if(playerController.noOfPickups == 3 && !keysCompleted)
            {
                keysCompleted = true;
                audioClipCounter = 0;
            }

            if (!introCompleted)
            {
                //play intro
                audioSource.clip = introDialog[audioClipCounter];
                audioSource.Play();
                audioClipCounter++;
                if (audioClipCounter >= introDialog.Length)
                {
                    audioClipCounter = 0;
                    introCompleted = true;
                }
            }
            else if (playerController.noOfPickups == 3)
            {
                //play completed dialog
                audioSource.clip = completedDialog[audioClipCounter];
                audioSource.Play();
                audioClipCounter++;
                if (audioClipCounter >= completedDialog.Length)
                {
                    audioClipCounter = 0;
                }
            }
            else
            {
                //play keys
                audioSource.clip = keysDialog[audioClipCounter];
                audioSource.Play();
                audioClipCounter++;
                if (audioClipCounter >= keysDialog.Length)
                {
                    audioClipCounter = 0;
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            isPlayerNear = false;
        }
    }
}
