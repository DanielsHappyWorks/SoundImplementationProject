using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public StateBehaviourScript stateControler;
    public Transform Player;
    public Transform OriginalPosition;
    public float MoveSpeed = 2.5f;
    public float MaxDist = 10;
    public float MinDist = 1f;
    public bool isIdling = true;
    Animator animator;
	private Rigidbody rb;
	public bool hitPlayer = false;

    public AudioClip[] walkClips;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
			
			isIdling = true;
		}
        else if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
			if (Vector3.Distance (transform.position, Player.position) >= MinDist) {
				transform.LookAt (Player);
				isIdling = false;
				rb.AddForce (transform.forward * MoveSpeed * Time.deltaTime);

			} else {
				isIdling = true;
			}

        }
        else {
            if (Vector3.Distance(transform.position, OriginalPosition.position) >= MinDist)
            {
                transform.LookAt(OriginalPosition);
				rb.AddForce (transform.forward * MoveSpeed * Time.deltaTime);

			} else {
				isIdling = true;
			}
				
        }

		if (isIdling) {
			animator.SetBool ("isWalking", false);
		} else {
			animator.SetBool("isWalking", true);

            if (!audioSource.isPlaying && walkClips != null)
            {
                audioSource.clip = walkClips[(int)UnityEngine.Random.Range(0, walkClips.Length)];
                audioSource.Play();
            }
        }

    }


    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            StartCoroutine(stateControler.Lose());
        }
    }
}
