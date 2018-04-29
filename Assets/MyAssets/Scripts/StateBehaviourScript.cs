using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateBehaviourScript : MonoBehaviour {
    public GameObject panel;
    public CanvasRenderer panelCR;
    public GameObject winPanelContent;
    public GameObject losePanelContent;
    public AudioClip[] winClips;
    public AudioClip loseClip;

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        panelCR.SetAlpha(0);
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator Win()
    {
        panel.GetComponent<Image>().CrossFadeAlpha(1f, 2.0f, false);
        audioSource.clip = winClips[0];
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        winPanelContent.SetActive(true);
        yield return new WaitForSeconds(4f);
        audioSource.clip = winClips[1];
        audioSource.volume = 0.7f;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public IEnumerator Lose()
    {
        panel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        audioSource.clip = loseClip;
        audioSource.Play();
        losePanelContent.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
