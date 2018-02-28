using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{

    public Transform Player;
    public Transform OriginalPosition;
    public float MoveSpeed = 2.5f;
    public float MaxDist = 10;
    public float MinDist = 1f;
    public bool isWalking = false;
    public bool isIdling = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            //Kill Player
        }
        else if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            if (Vector3.Distance(transform.position, Player.position) >= MinDist) {
                transform.LookAt(Player);
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                if (!isWalking){
                    animator.Play("Idle");
                    isWalking = true;
                    isIdling = false;
                }
            } 
        }
        else {
            if (Vector3.Distance(transform.position, OriginalPosition.position) >= MinDist)
            {
                transform.LookAt(OriginalPosition);
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                if (!isWalking){
                    animator.Play("Idle");
                    isWalking = true;
                    isIdling = false;
                }
            }
        }
        if (!isIdling) {
            animator.Play("Idle");
            isIdling = true;
            isWalking = false;
        }
    }
}
