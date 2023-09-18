using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressScript : MonoBehaviour
{
    public float maxStress;
    public float currentStress;

    StressBarScript stressBarScript;

    private void Start()
    {
        stressBarScript = FindObjectOfType<StressBarScript>();

        stressBarScript.UpdateStressBar(currentStress, maxStress);

    }

    public void ChangeStressAmount(float stressAmount)
    {
        currentStress += stressAmount;
        stressBarScript.UpdateStressBar(currentStress, maxStress);
    }

}
