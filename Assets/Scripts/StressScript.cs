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
        
        if(stressBarScript != null)
            stressBarScript.UpdateStressBar(currentStress, maxStress);

    }

    public void ChangeStressAmount(float stressAmount)
    {
        currentStress += stressAmount;
        stressBarScript.UpdateStressBar(currentStress, maxStress);

        if(currentStress >= maxStress)
        {
            FindObjectOfType<ExplosionSpawnerScript>().SpawnExplosion(this.gameObject.transform.position);
            Debug.Log("Spawned explosion");
            Destroy(this.gameObject);
        }
    }

}
