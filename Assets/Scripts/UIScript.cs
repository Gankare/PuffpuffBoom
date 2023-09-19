using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image stressBarImage;
    public GameObject[] ammoCounterArray;

    ShootingScript playerShootingScript;

    private void Start()
    {
        playerShootingScript = FindObjectOfType<ShootingScript>();
    }

    public void UpdateStressBar(float currentStress, float maxStress)
    {
        stressBarImage.fillAmount = currentStress / maxStress;
    }

    public void UpdateAmmoCounter()
    {
        for (int i = 0; i < ammoCounterArray.Length; i++)
        {
            ammoCounterArray[i].SetActive(false);
        }
        for (int i = 0; i < playerShootingScript.currentAmmo; i++)
        {
            ammoCounterArray[i].SetActive(true);
        }
    }

}
