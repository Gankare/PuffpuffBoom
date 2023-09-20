using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandlerScript : MonoBehaviour
{
    public Image fade;
    public void StartGame()
    {
        StartCoroutine(StartGameAfter());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator StartGameAfter()
    {
        fade.CrossFadeAlpha(255, 2, true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene");
    }
}
