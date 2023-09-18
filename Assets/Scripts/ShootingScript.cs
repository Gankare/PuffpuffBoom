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
    private float reloadTimer;
    public float reloadTimeAmount;

    public int spikeDamage = 1;


    public int currentAmmo = 5;
    public int maxAmmo = 5;
    public GameObject[] ammoCounterArray;
    public GameObject childRotation;
    private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        currentAmmo = maxAmmo;
        UpdateAmmoCounter();

    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        childRotation.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        reloadTimer += Time.deltaTime;

        if (currentAmmo < maxAmmo && reloadTimer >= reloadTimeAmount)
        {
            currentAmmo++;
            reloadTimer = 0;
            UpdateAmmoCounter();
        }
        if (currentAmmo > 0 && Input.GetKeyDown(KeyCode.Space) || currentAmmo > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            reloadTimer = 0;
            Shoot();
        }
    }
    private void Shoot()
    {

        Instantiate(spikePrefab, transform.position, childRotation.transform.rotation);
        currentAmmo--;

      
        UpdateAmmoCounter();

    }

    public void UpdateAmmoCounter()
    {
        for (int i = 0; i < ammoCounterArray.Length; i++)
        {
            ammoCounterArray[i].SetActive(false);
        }
        for (int i = 0; i < currentAmmo; i++)
        {
            ammoCounterArray[i].SetActive(true);
        }

    }
}
