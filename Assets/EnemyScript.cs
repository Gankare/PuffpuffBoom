using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed = 10;
    public float knockBackPower;
    Transform target;
    Rigidbody2D rigidbody2D;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rigidbody2D.velocity = direction * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with thing");

        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");

            Vector3 moveDirection = rigidbody2D.transform.position - collision.transform.position;
            rigidbody2D.AddForce(-moveDirection.normalized * -knockBackPower);

            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

        }

        //if (collision.gameObject.GetComponent<Laser>() != null)
        //{

        //}
    }
}
