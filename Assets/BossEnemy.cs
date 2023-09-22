using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float movementSpeed = 10;
    private AudioSource electroBoltSound;

    public int maxHealth = 5;
    public int currentHealth;

    public Transform attackTarget;
    public Transform[] moveTarget;
    public Rigidbody2D rB;
    public GameObject boosObject;
    public static bool GameWon = false;

    private void Start()
    {
        electroBoltSound = GetComponent<AudioSource>();
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
        if (attackTarget == null) { Debug.Log("The player does not have the Player tag on its gameobject, the enemies have no target and will not move."); }

        currentHealth = maxHealth;
    }

    public int moveTargetID;
    private float changeMoveDirTimer = 2;

    private float shootTimer = 1;

    public GameObject ballPrefab;

    private float minShootRange = 0.4f;


    private void Update()
    {


        if (RoomScript.nextRoomPause)
            return;


        if(currentHealth == maxHealth / 2)
        {
            minShootRange = 0.1f;
        }


        if (changeMoveDirTimer >= 0)
        {
            changeMoveDirTimer -= Time.deltaTime;
        }
        else
        {
            if(moveTargetID == 1) { moveTargetID = 0; }
            else if (moveTargetID == 0) { moveTargetID = 1; }

            changeMoveDirTimer = Random.Range(0.5f, 2.0f);
        }




        if(shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            shootTimer = Random.Range(minShootRange, 0.7f);

            Vector3 enemyDir = transform.position - attackTarget.position;
            float angle = (Mathf.Atan2(enemyDir.y, enemyDir.x) * Mathf.Rad2Deg) + 90;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            electroBoltSound.PlayOneShot(electroBoltSound.clip);
            Instantiate(ballPrefab, transform.position, rotation);

        }


        Vector3 dir = transform.position - moveTarget[moveTargetID].position;
        //float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 direction = moveTarget[moveTargetID].position - transform.position;
        direction.Normalize();

        rB.velocity = direction * movementSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            currentHealth -= collision.gameObject.GetComponent<SpikeScript>().damage;
            collision.gameObject.GetComponent<SpikeScript>().Explode();

            if (currentHealth <= 0)
            {
                FindObjectOfType<ExplosionSpawnerScript>().SpawnBossBubbleExplosion(this.gameObject.transform.position);
                GameWon = true;
                Destroy(boosObject);
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
