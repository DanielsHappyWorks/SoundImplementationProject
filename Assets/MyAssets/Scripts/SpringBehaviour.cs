using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpringBehaviour : MonoBehaviour {

	public RigidbodyFirstPersonController playerController;
	private float originalJump;
	public float springForce;
	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<RigidbodyFirstPersonController> ();
		originalJump = playerController.movementSettings.JumpForce;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player") {
			playerController.movementSettings.JumpForce = springForce;
			playerController.m_Jump = true;
		}
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {
			playerController.movementSettings.JumpForce = originalJump;
			playerController.m_Jump = false;


		}
	}
}
