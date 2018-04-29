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

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && rbfpc.jumpClips != this.jumpClips)
        {
            rbfpc.jumpClips = this.jumpClips;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rbfpc.walkClips = this.walkClips;
            rbfpc.runClips = this.runClips;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().walkClips = this.walkClips;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && rbfpc.walkClips != this.walkClips)
        {
            rbfpc.walkClips = this.walkClips;
            rbfpc.runClips = this.runClips;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().walkClips = this.walkClips;
        }
    }
}
