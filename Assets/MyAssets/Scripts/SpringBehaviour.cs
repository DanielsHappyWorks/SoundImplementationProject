using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpringBehaviour : MonoBehaviour {

	public RigidbodyFirstPersonController playerController;
    private AudioSource audioSource;
    private float originalJump;
	public float springForce;
    public bool isSetToJump;
    // Use this for initialization
    void Start () {
		playerController = FindObjectOfType<RigidbodyFirstPersonController> ();
		originalJump = playerController.movementSettings.JumpForce;
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
		if(isSetToJump && playerController.Grounded)
        {
            playerController.m_Jump = true;
            audioSource.Play();
        }
	}

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player") {
			playerController.movementSettings.JumpForce = springForce;
            isSetToJump = true;
        }
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {
			playerController.movementSettings.JumpForce = originalJump;
            isSetToJump = false;
		}
	}
}
