using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollisionBehaviour : MonoBehaviour {
    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
    }
}
