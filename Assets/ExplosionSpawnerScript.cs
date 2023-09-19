using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnerScript : MonoBehaviour
{
    public GameObject KABOOM_prefab;

    public void SpawnExplosion(Vector3 position)
    {
        GameObject newExplosion = Instantiate(KABOOM_prefab, position, transform.rotation);
        Destroy(newExplosion, 1f);
    }
}
