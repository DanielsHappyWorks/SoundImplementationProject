using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour {

	bool isGateOpen = false;
	bool playerNear = false;

	Quaternion gateClosed = Quaternion.identity;
	Quaternion gateOpened = Quaternion.identity;

	public float gateOpenAngle = 90f;
	public float gateClosedAngle = 0;
	public float gateAnimationSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		gateClosed = Quaternion.Euler (0, gateClosedAngle, 0);
		gateOpened = Quaternion.Euler (0, gateOpenAngle, 0);

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
		while (Quaternion.Angle (transform.localRotation, destination) > 0f) {
			transform.localRotation = Quaternion.Slerp(transform.localRotation, destination, Time.deltaTime * gateAnimationSpeed);
			yield return null;
		}

		yield return null;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && !isGateOpen && playerNear) {
			StartCoroutine(this.moveGate(gateOpened));
			isGateOpen = true;

		} else if (Input.GetKeyDown (KeyCode.E) && isGateOpen && playerNear) {
			StartCoroutine(this.moveGate(gateClosed));
			print ("closing gate..." + transform.localRotation.eulerAngles.y);
			isGateOpen = false;
		}

	}
}
