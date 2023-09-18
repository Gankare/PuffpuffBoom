using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed = 10;

    Transform target;
    Rigidbody2D rb2D;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb2D.velocity = direction * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with thing");

        //if (collision.gameObject.GetComponent<Laser>() != null)
        //{
            
        //}
    }
}
