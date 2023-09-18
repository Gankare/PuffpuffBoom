using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBarScript : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Image stressBarImage;

    public void UpdateStressBar()
    {
        stressBarImage.fillAmount =  currentHealth / maxHealth;
    }

    private void Update()
    {
        UpdateStressBar();
    }
}
