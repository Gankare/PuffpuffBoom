using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressScript : MonoBehaviour
{
    public float maxStress;
    public float currentStress;

    UIScript stressBarScript;

    private void Start()
    {
        stressBarScript = FindObjectOfType<UIScript>();
        
        if(stressBarScript != null)
            stressBarScript.UpdateStressBar(currentStress, maxStress);
    }

    public void ChangeStressAmount(float stressAmount)
    {
        currentStress += stressAmount;
        stressBarScript.UpdateStressBar(currentStress, maxStress);

        if(currentStress >= maxStress)
        {
            //Spawn explosion
            var explosionManager = FindObjectOfType<ExplosionSpawnerScript>();
            if(explosionManager == null) { Debug.Log("NO EXPLOSION MANAGER PREFAB IN SCENE!"); }
            else { explosionManager.SpawnExplosion(this.transform.position); }            
            Destroy(this.gameObject);
        }
    }

}
