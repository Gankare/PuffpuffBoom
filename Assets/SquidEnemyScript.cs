using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidEnemyScript : MonoBehaviour
{

    public int maxHealth = 5;
    public int currentHealth;

    private Transform target;

    private float shootTimer;
    public float shootCoolDownAmount;

    public GameObject spikePrefab;

    public Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null) { Debug.Log("The player does not have the Player tag on its gameobject, the enemies have no target and will not move."); }
    }

    private void Update()
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
        }

        if(shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("Shoot", true);
        }

    }

    public void Shoot()
    {
        shootTimer = shootCoolDownAmount;

        Vector3 dir = transform.position - target.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(spikePrefab, transform.position, rotation);
        anim.SetBool("Shoot", false);

    }

    public float flashTime;
    public Color origionalColor;
    public SpriteRenderer sprite_renderer;
    public float stressAmountToApplyToPlayer;
    void FlashRed()
    {
        sprite_renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sprite_renderer.color = origionalColor;
    }
    public Rigidbody2D rB;
    public float knockBackPower;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            currentHealth -= collision.gameObject.GetComponent<SpikeScript>().damage;
            collision.gameObject.GetComponent<SpikeScript>().Explode();

            if (currentHealth <= 0)
            {
                RoomScript.enemiesDead++;
                FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);
                Destroy(this.gameObject);
            }
            FlashRed();
        }

        if (collision.gameObject.tag == "Player")
        {
            Vector3 moveDirection = rB.transform.position - collision.transform.position;

            Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody2D.AddForce(moveDirection.normalized * -knockBackPower);

            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(stressAmountToApplyToPlayer);

            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                RoomScript.enemiesDead++;
                FindObjectOfType<ExplosionSpawnerScript>().SpawnBubbleExplosion(this.gameObject.transform.position);
                Destroy(this.gameObject);
            }
            FlashRed();
        }
    }

}
