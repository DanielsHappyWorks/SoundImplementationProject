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

    // Use this for initialization
    void Start () {
        panelCR.SetAlpha(0);
    }

    public IEnumerator Win()
    {
        panel.GetComponent<Image>().CrossFadeAlpha(1f, 2.0f, false);
        yield return new WaitForSeconds(2f);
        winPanelContent.SetActive(true);
        yield return new WaitForSeconds(5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public IEnumerator Lose()
    {
        panel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        losePanelContent.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
