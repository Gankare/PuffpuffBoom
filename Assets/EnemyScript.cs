using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed = 10;
    public float knockBackPower;
    public float stressAmount;
    Transform target;
    private Rigidbody2D rB;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rB.velocity = direction * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with thing");

        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");

            Vector3 moveDirection = rB.transform.position - collision.transform.position;
            rB.AddForce(-moveDirection.normalized * -knockBackPower);

            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(stressAmount);
        }

    }
}
