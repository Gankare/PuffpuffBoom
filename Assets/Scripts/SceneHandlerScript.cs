using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandlerScript : MonoBehaviour
{
    public Image fade;
    public Image pufferFish;
    private void Start()
    {
        fade.CrossFadeAlpha(1, 0, true);
    }

    public void StartTutorial()
    {
        StartCoroutine(StartTutorialAfter());
    }
    public void StartGame()
    {
        StartCoroutine(StartGameAfter());
    }
    public void ReturnToMenu()
    {
        StartCoroutine(GoToMenuAfter());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator StartTutorialAfter()
    {
        pufferFish.CrossFadeAlpha(0, 0.2f, true);
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("TutorialScene");
    }
    IEnumerator StartGameAfter()
    {
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator GoToMenuAfter()
    {
        fade.CrossFadeAlpha(255, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuScene");
    }
}
