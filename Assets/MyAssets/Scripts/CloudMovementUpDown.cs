using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementUpDown : MonoBehaviour {
	public float movementSpeed;
	private float maxHeight;
	private float initialHeight;
	private bool isMaxHeight;
	// Use this for initialization
	void Start () {
		movementSpeed = 5;
		initialHeight = transform.position.y;
		maxHeight = transform.position.y + 10;
		isMaxHeight = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move()
	{
		//move up until max height is reached and then move down and repeat
		if (transform.position.y < maxHeight && !isMaxHeight) {
			transform.Translate (Vector3.up * Time.deltaTime * movementSpeed);
		} else if(transform.position.y > initialHeight && isMaxHeight){
			transform.Translate(-Vector3.up * Time.deltaTime * movementSpeed);
		}

		if (transform.position.y >= maxHeight) {
			isMaxHeight = true;
		} else if (transform.position.y <= initialHeight) {
			isMaxHeight = false;
		}
	}

}
