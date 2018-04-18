using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour {

	bool isGateOpen = false;
	bool playerNear = false;
    bool gateAction = false;

    Quaternion gateClosed = Quaternion.identity;
	Quaternion gateOpened = Quaternion.identity;

    AudioSource audioSource;

	public float gateOpenAngle = 90;
	public float gateClosedAngle = 0;
	public float gateAnimationSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		gateClosed = Quaternion.Euler (0, gateClosedAngle, 0);
		gateOpened = Quaternion.Euler (0, gateOpenAngle, 0);
        audioSource = GetComponent<AudioSource>();

    }

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player" ) {
			playerNear = true;
		}
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {			
			playerNear = false;
		}
	}

	public IEnumerator moveGate(Quaternion destination) {
		while (Quaternion.Angle (transform.localRotation, destination) > 4.0f) {
			transform.localRotation = Quaternion.Slerp(transform.localRotation, destination, Time.deltaTime * gateAnimationSpeed);
			yield return null;
		}

		if (isGateOpen) {
			isGateOpen = false;
		} else {
			isGateOpen = true;
		}
        gateAction = false;
        yield return null;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && !isGateOpen && playerNear && !gateAction) {
            if (audioSource) {
                audioSource.Play();
            }
            gateAction = true;
            StartCoroutine(this.moveGate(gateOpened));

		} else if (Input.GetKeyDown(KeyCode.E) &&  isGateOpen && playerNear && !gateAction) {
            if (audioSource)
            {
                audioSource.Play();
            }
            gateAction = true;
            StartCoroutine(this.moveGate(gateClosed));
		}

	}
}
