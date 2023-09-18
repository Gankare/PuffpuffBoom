using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private float timer;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;

        if (timer >= 4)
            Destroy(gameObject);
    }
}
