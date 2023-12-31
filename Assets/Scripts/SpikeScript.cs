using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    public int damage;

    private float timer;

    public bool isEnemyBullet;

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

    public void Explode()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && isEnemyBullet)
        {
            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(damage);
            FindObjectOfType<ExplosionSpawnerScript>().SpawnSmallBubbleExplosion(this.transform.position);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Rocks")
        {
            FindObjectOfType<ExplosionSpawnerScript>().SpawnSmallBubbleExplosion(this.transform.position);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Mine")
        {
            FindObjectOfType<ExplosionSpawnerScript>().SpawnSmallBubbleExplosion(this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
