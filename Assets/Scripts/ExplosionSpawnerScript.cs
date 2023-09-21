using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnerScript : MonoBehaviour
{
    public GameObject KABOOM_prefab;
    public GameObject bubbleExplosion;
    public GameObject smallBubbleExplosion;
    public GameObject bossBubbleExplosion;
    private AudioSource bombSound;
    public AudioSource deathSound;
    public AudioSource bossDeathSound;

    private void Start()
    {
        bombSound = GetComponent<AudioSource>();
    }
    public void SpawnExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -6);


        GameObject newExplosion = Instantiate(KABOOM_prefab, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned explosion");
    }
    public void SpawnBubble(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -5);
        GameObject newExplosion = Instantiate(bubbleExplosion, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned bubble explosion");
        deathSound.Play();
    }
    public void SpawnBubbleExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -5);
        GameObject newExplosion = Instantiate(bubbleExplosion, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned bubble explosion");
        bombSound.Play();
    }

    public void SpawnSmallBubbleExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -5);
        GameObject newExplosion = Instantiate(smallBubbleExplosion, spawnPos, transform.rotation);
        Destroy(newExplosion, 1f);
        Debug.Log("Spawned bubble explosion");

    }
    public void SpawnBossBubbleExplosion(Vector3 position)
    {
        Vector3 spawnPos = new Vector3(position.x, position.y, -5);
        GameObject newExplosion = Instantiate(bossBubbleExplosion, spawnPos, transform.rotation);
        Destroy(newExplosion, 6f);
        Debug.Log("Spawned bubble explosion");
        bossDeathSound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnBubbleExplosion(FindObjectOfType<MovementScript>().gameObject.transform.position);

        }
    }
}
