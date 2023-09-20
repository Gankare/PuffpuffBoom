using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image stressBarImage;
    public GameObject[] ammoCounterArray;

    ShootingScript playerShootingScript;

    public Animator fadeAnim;

    private void Start()
    {
        playerShootingScript = FindObjectOfType<ShootingScript>();
        UpdateAmmoCounter();
    }

    public void UpdateStressBar(float currentStress, float maxStress)
    {
        stressBarImage.fillAmount = currentStress / maxStress;
    }

    public void UpdateAmmoCounter()
    {
        if(playerShootingScript == null) { return; } //If player is dead

        for (int i = 0; i < ammoCounterArray.Length; i++)
        {
            ammoCounterArray[i].SetActive(false);
        }
        for (int i = 0; i < playerShootingScript.currentAmmo; i++)
        {
            //Debug.Log(i);
            ammoCounterArray[i].SetActive(true);
        }
    }

    public void RespawnMethod()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }


    public void FadeImage(bool fadeIn)
    {
        fadeAnim.SetBool("FadeIn", fadeIn);
    }

}
