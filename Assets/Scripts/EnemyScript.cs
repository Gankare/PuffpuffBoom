using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed = 10;
    public float maxMovementSpeed = 10;

    public float knockBackPower;
    public float selfKnockBackPower;
    public float stressAmountToApplyToPlayer;

    public int maxHealth = 5;
    public int currentHealth;

    public Transform target;
    private Rigidbody2D rB;

    private bool isGettingKnockedBack;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target == null) { Debug.Log("The player does not have the Player tag on its gameobject, the enemies have no target and will not move."); }

        rB = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!PauseGameScript.gamePaused) 
        { 
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            if (!isGettingKnockedBack)
            {
                rB.velocity = direction * movementSpeed;
            }
            else
            {
                if(rB.velocity.magnitude <= 0.5)
                {
                    isGettingKnockedBack = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with thing");

        if (collision.gameObject.tag == "Spike")
        {
            currentHealth -= collision.gameObject.GetComponent<SpikeScript>().damage;
            collision.gameObject.GetComponent<SpikeScript>().Explode();

            if(currentHealth <= 0)
            {
                RoomScript.enemiesDead++;
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player");

            Vector3 moveDirection = rB.transform.position - collision.transform.position;

            isGettingKnockedBack = true;
            rB.AddForce(-moveDirection.normalized * -selfKnockBackPower);

            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(stressAmountToApplyToPlayer);
        }

    }
}
