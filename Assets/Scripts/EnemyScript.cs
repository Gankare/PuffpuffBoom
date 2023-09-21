using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementSpeed = 10;
    public float maxMovementSpeed = 10;
    public float reducedMovementSpeed = 4;

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
        if (!PauseGameScript.gameSlowed && !PauseGameScript.gamePaused && !RoomScript.nextRoomPause)
        {
            if (target == null) { return; } //If player dies

            //Look at player
            Vector3 dir = transform.position - target.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            if (!isGettingKnockedBack)
            {
                rB.velocity = direction * movementSpeed;
            }
            else
            {
                if (rB.velocity.magnitude <= 0.5)
                {
                    isGettingKnockedBack = false;
                }
            }
        }
        else if(rB != null)
            rB.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Rocks")
            movementSpeed = reducedMovementSpeed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rocks")
            movementSpeed = maxMovementSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            currentHealth -= collision.gameObject.GetComponent<SpikeScript>().damage;
            collision.gameObject.GetComponent<SpikeScript>().Explode();

            if(currentHealth <= 0)
            {
                FindObjectOfType<RoomScript>().KilledEnemy();
                FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);
                Destroy(this.gameObject);
            }
            FlashRed();
        }

        if (collision.gameObject.tag == "Player")
        {
            Vector3 moveDirection = rB.transform.position - collision.transform.position;

            isGettingKnockedBack = true;
            rB.AddForce(-moveDirection.normalized * -selfKnockBackPower);

            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(stressAmountToApplyToPlayer);

            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                FindObjectOfType<RoomScript>().KilledEnemy();
                FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);
                Debug.Log("ENEMY DEAD");
                Destroy(this.gameObject);
            }
            FlashRed();
        }
    }

    public float flashTime;
    public Color origionalColor;
    public SpriteRenderer sprite_renderer;

    void FlashRed()
    {
        sprite_renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sprite_renderer.color = origionalColor;
    }
}
