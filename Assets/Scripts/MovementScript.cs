using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector2 position;
    private Rigidbody2D rigidBody;
    private Vector2 acceleration;
    private Vector2 velocity;
    public float speed = 500;
    public Collider2D playerCollider;
    RoomScript roomScript;

    void Start()
    {
        roomScript = FindObjectOfType<RoomScript>();
        position = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }
     
    void Update()
    {
        if(!RoomScript.nextRoomPause) 
        {
            if (!PauseGameScript.gameSlowed && !PauseGameScript.gamePaused)
            { 
                if (Input.GetKey(KeyCode.W))
                {
                    acceleration += Vector2.up;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    acceleration += Vector2.down;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    acceleration += Vector2.left;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    acceleration += Vector2.right;
                }

                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    acceleration = Vector2.zero;
                }
                if (rigidBody.velocity.sqrMagnitude >= 25)
                {
                    //rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, 5);
                    //Debug.Log("max speed");
                }
            }
            else
                rigidBody.velocity = Vector2.zero;
        }


        if (RoomScript.nextRoomPause)
        {
            playerCollider.enabled = false;
        }
        else
        {
            playerCollider.enabled = true;
        }
    }
    private void FixedUpdate()
    {
        if (!RoomScript.nextRoomPause) 
        { 
            if (acceleration.magnitude > 1)
            {
                acceleration.Normalize();
            }
            velocity = acceleration * speed * Time.fixedDeltaTime;
            rigidBody.AddForce(velocity);
        }
    }



}

