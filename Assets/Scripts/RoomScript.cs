using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class RoomScript : MonoBehaviour
{
    //For camera movement
    public static int level;
    public static int enemiesDead;
    public GameObject[] rooms;

    //For player movement
    public static bool nextRoomPause;
    public float roomTransitionSpeed;
    private float pauseTimer;
    private Transform playerTransform;
    public Transform room2PlayerPos;
    public Transform room3PlayerPos;
    public Transform room4PlayerPos;
    public TilemapCollider2D rockTileMap;
    public GameObject doorColliders;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        level = 1;
        enemiesDead = 0;

        //Sets all rooms to deactive in the beginning
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
    }
    private void Update()
    {
        pauseTimer += Time.deltaTime;
        
        if (level == 1 && enemiesDead >= 1)
        {
            pauseTimer = 0;
            level = 2; 
            enemiesDead = 0;
            Debug.Log("next level");
        }
        else if (level == 2 && enemiesDead >= 2)
        {
            pauseTimer = 0;
            level = 3;
            enemiesDead = 0;
        }
        else if (level == 3 && enemiesDead >= 3)
        {
            pauseTimer = 0;
            level = 4;
            enemiesDead = 0;
        }
        else if (level == 4 && enemiesDead >= 4)
        {
            //Spawn boss or win game
        }

        //
      
        for (int i = 0; i < level; i++)
        {
            rooms[i].SetActive(true);
        }

        if(level == 2 && pauseTimer < 4)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room2PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else if (level == 3 && pauseTimer < 4)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room3PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else if (level == 4 && pauseTimer < 4)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room4PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else
        {
            doorColliders.SetActive(true);
            rockTileMap.enabled = true;
            nextRoomPause = false;
        }
    }
}
