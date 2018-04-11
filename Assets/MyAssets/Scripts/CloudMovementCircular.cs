using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CloudMovementCircular : MonoBehaviour {

    // Use this for initialization
    float timeCounter = 0;
    Vector3 prevPos;
    Vector3 originalPos;
    bool isOnCloudOne = false;

    private RigidbodyFirstPersonController playerController;
    Vector3 playerPosition;
    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * 100;
        transform.position = Quaternion.AngleAxis(timeCounter, Vector3.up) * new Vector3(4f, 0f) + originalPos;
        prevPos = transform.position;
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            //set is on cloud == true
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            //set is on cloud == false
        }
    }
}
