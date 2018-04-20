using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementUpOnly : MonoBehaviour {
	public float movementSpeed;
	private float maxHeight;
	private float initialHeight;
	private bool isMaxHeight;
	private bool isPlayerColliding;
	// Use this for initialization
	void Start () {
		movementSpeed = 5;
		initialHeight = transform.position.y;
		maxHeight = transform.position.y + 35;
		isMaxHeight = false;
		isPlayerColliding = false;
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move()
	{
		//move up until max height is reached and then move down and repeat

		if (transform.position.y < maxHeight && !isMaxHeight && isPlayerColliding) {
			transform.Translate (Vector3.up * Time.deltaTime * movementSpeed);
		}

		if (transform.position.y >= maxHeight) {
			isMaxHeight = true;
		} else if (transform.position.y <= initialHeight) {
			isMaxHeight = false;
		}

        if(!isPlayerColliding && transform.position.y > initialHeight)
        {
            transform.Translate( -1 * Vector3.up * Time.deltaTime * movementSpeed);
        }
	}

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player" ) {
			isPlayerColliding = true;
		}
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {			
			isPlayerColliding = false;

		}
	}

}
