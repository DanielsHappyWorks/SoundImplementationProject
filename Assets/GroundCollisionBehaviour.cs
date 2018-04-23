using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GroundCollisionBehaviour : MonoBehaviour {
    public AudioClip[] walkClips;
    public AudioClip[] runClips;
    public AudioClip[] jumpClips;
    RigidbodyFirstPersonController rbfpc;

    // Use this for initialization
    void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        rbfpc = obj.GetComponent<RigidbodyFirstPersonController>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col) {
        if(col.tag == "Player")
        {
            rbfpc.jumpClips = this.jumpClips;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            rbfpc.walkClips = rbfpc.walkClipsDefault;
            rbfpc.runClips = rbfpc.runClipsDefault;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rbfpc.walkClips = this.walkClips;
            rbfpc.runClips = this.runClips;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rbfpc.jumpClips = rbfpc.jumpClipsDefault;
        }
    }
}
