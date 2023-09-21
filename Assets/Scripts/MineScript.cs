using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public float knockBackPower;
    public Rigidbody2D rB;
    public float stressAmountToAdd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 moveDirection = rB.transform.position - collision.transform.position;
            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(stressAmountToAdd);

            //Spawn explosion
            var explosionManager = FindObjectOfType<ExplosionSpawnerScript>();
            if(explosionManager == null) { Debug.Log("NO EXPLOSION MANAGER PREFAB IN SCENE!"); }
            else { explosionManager.SpawnExplosion(this.transform.position); }

            FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);
            FindObjectOfType<CameraShakeScript>().TriggerShake();

            Destroy(this.gameObject);
        }
    }



}
