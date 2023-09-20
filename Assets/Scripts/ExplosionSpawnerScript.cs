using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnerScript : MonoBehaviour
{
    public GameObject KABOOM_prefab;
    public GameObject bubbleExplosion;
    public void SpawnExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -6);


        GameObject newExplosion = Instantiate(KABOOM_prefab, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned explosion");
    }

    public void SpawnBubbleExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -5);


        GameObject newExplosion = Instantiate(bubbleExplosion, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned bubble explosion");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnBubbleExplosion(FindObjectOfType<MovementScript>().gameObject.transform.position);

        }
    }
}
