using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        if(stressAmount > 0) { FlashRed(); }

        if(currentStress >= maxStress)
        {
            //Spawn explosion
            var explosionManager = FindObjectOfType<ExplosionSpawnerScript>();
            if(explosionManager == null) { Debug.Log("NO EXPLOSION MANAGER PREFAB IN SCENE!"); }
            else { explosionManager.SpawnExplosion(this.transform.position); }

            FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);

            FindObjectOfType<UIScript>().RespawnMethod();
            Destroy(this.gameObject);
        }
    }


    public float flashTime;
    public Color origionalColor;
    public SpriteRenderer sprite_renderer;

    void FlashRed()
    {
        sprite_renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sprite_renderer.color = origionalColor;
    }
}
