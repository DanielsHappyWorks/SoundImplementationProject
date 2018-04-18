using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PickupBehaviour : MonoBehaviour {
	private RigidbodyFirstPersonController playerController;
	private bool isDestroyed;
	private bool isPlayerNear;
	private float rotateDegreesPerSec;

	private float movementSpeed;
	private float maxHeight;
	private float initialHeight;
	private bool isMaxHeight;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
		playerController = FindObjectOfType<RigidbodyFirstPersonController> ();
		isDestroyed = false;
		isPlayerNear = false;
		rotateDegreesPerSec = 120;
		initialHeight = transform.localPosition.y;
		maxHeight = initialHeight + 0.5f;
		movementSpeed = 0.3f;
		isMaxHeight = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		Pickup ();
		transform.Rotate (Vector3.right * (Time.deltaTime * rotateDegreesPerSec));
		Move ();
									
	}

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player" ) {
			isPlayerNear = true;
		}
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {			
			isPlayerNear = false;
		}
	}

	//pickup key  pickup key if E is pressed and increment number of pickups 
	void Pickup()
	{
		if (!isDestroyed && isPlayerNear && Input.GetKeyDown (KeyCode.E)) {
            audioSource.Play();
            isDestroyed = true;
			playerController.noOfPickups++;
		}

        if(isDestroyed && !audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
	}

	void Move()
	{
		//move up until max height is reached and then move down and repeat
		if (transform.localPosition.y < maxHeight && !isMaxHeight) {
			transform.Translate (Vector3.right * Time.deltaTime * movementSpeed);
		} else if(transform.localPosition.y > initialHeight && isMaxHeight){
			transform.Translate(-Vector3.right * Time.deltaTime * movementSpeed);
		}

		if (transform.localPosition.y >= maxHeight) {
			isMaxHeight = true;
		} else if (transform.localPosition.y <= initialHeight) {
			isMaxHeight = false;
		}
	}

		
}
