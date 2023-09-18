using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBarScript : MonoBehaviour
{

    public Image stressBarImage;

 

    public void UpdateStressBar(float currentStress, float maxStress)
    {
        stressBarImage.fillAmount = currentStress / maxStress;
    }



}
