using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CloudMovementCircular : MonoBehaviour {

    // Use this for initialization
    float timeCounter = 0;
    Vector3 prevPos;
    Vector3 originalPos;
    bool isPlayerColliding;
	Vector3 originalPlayerPosition;

    private RigidbodyFirstPersonController playerController;
    Vector3 playerPosition;
    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
		isPlayerColliding = false;
		originalPlayerPosition = playerController.transform.position;
    }

    // Update is called once per frame
	//Moves cloud in circle, as well as player if colliding
    void Update()
    {
        timeCounter += Time.deltaTime * 70;
        transform.position = Quaternion.AngleAxis(timeCounter, Vector3.up) * new Vector3(10f, 0f) + originalPos;
        prevPos = transform.position;
		if (isPlayerColliding) {
			playerController.transform.position = Quaternion.AngleAxis (timeCounter, Vector3.up) * new Vector3 (10f, 0f) + playerController.transform.position;
		}
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
			isPlayerColliding = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
			isPlayerColliding = false;
        }
    }
}
