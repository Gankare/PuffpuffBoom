using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject spikePrefab;
    public float shootSpeed;
    private Vector3 shootDirection;
    private float reloadTimer;
    public int ammo = 8;

    public GameObject[] ammoCounter;
    public GameObject ammoObject;

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (ammo < 8 && reloadTimer >= 1)
        {
            ammo++;
            reloadTimer = 0;
        }
        if (ammo > 0 && Input.GetKeyDown(KeyCode.Space) || ammo > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(spikePrefab, transform.position, transform.rotation);
        ammo--;
        for(int i = 0; i < ammo; i++)
        {
            
        }
    }
}