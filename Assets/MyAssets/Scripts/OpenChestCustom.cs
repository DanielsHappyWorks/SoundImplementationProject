using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenChest : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float factor;

    Quaternion closedAngle;
    Quaternion openedAngle;

    AudioSource audioSource;

    public bool closing;
    public bool opening;

    public float speed = 0.5f;

	private bool isPlayerNear;

	private RigidbodyFirstPersonController playerController;

    int newAngle = 127;

    // Use this for initialization
    void Start () {
        openedAngle = transform.rotation;
        closedAngle = Quaternion.Euler(transform.eulerAngles + Vector3.right * newAngle);
		playerController = FindObjectOfType<RigidbodyFirstPersonController> ();
		isPlayerNear = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		CheckInteraction ();
        if (closing)
        {
            factor += speed * Time.deltaTime;

            if (factor > 1.0f)
            {
                factor = 1.0f;
            }
        }
        if (opening)
        {
            factor -= speed * Time.deltaTime;

            if (factor < 0.0f)
            {
                factor = 0.0f;
            }
        }

        transform.rotation = Quaternion.Lerp(openedAngle, closedAngle, factor);
	}

    //You probably want to call this somewhere
    void Close()
    {
        closing = true;
        opening = false;
        audioSource.Play();
    }

    void Open()
    {
        opening = true;
        closing = false;
        audioSource.Play();
    }

	//New - Added code to trigger chest opening
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

	//New - Checks requirements to allow for chest opening
	void CheckInteraction()
	{
		if (isPlayerNear && Input.GetKeyDown (KeyCode.E) && playerController.noOfPickups == 3) {
			Open ();
        }
			
	}
}
