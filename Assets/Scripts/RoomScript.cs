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
    //Simple quick enemy counter
    public int enemiesInRoom1;
    public int enemiesInRoom2;
    public int enemiesInRoom3;
    public int enemiesInRoom4;
    public int enemiesInRoom5;

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
    public Transform room5PlayerPos;
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
    public void KilledEnemy()
    {
        enemiesDead++;

        if (level == 1 && enemiesDead >= enemiesInRoom1)
        {
            enemiesDead = 0;
            pauseTimer = 0;
            level = 2;
        }
        if (level == 2 && enemiesDead >= enemiesInRoom2)
        {
            enemiesDead = 0;
            pauseTimer = 0;
            level = 3;
        }
        if (level == 3 && enemiesDead >= enemiesInRoom3)
        {
            enemiesDead = 0;
            pauseTimer = 0;
            level = 4;
        }
        else if (level == 4 && enemiesDead >= enemiesInRoom4)
        {
            enemiesDead = 0;
            pauseTimer = 0;
            level = 5;
            Debug.Log("LEVEL 5");
        }
    }

    private void Update()
    {
        pauseTimer += Time.deltaTime;
        
        for (int i = 0; i < level; i++)
        {
            rooms[i].SetActive(true);
        }

        if(level == 2 && pauseTimer < 2.5)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room2PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else if (level == 3 && pauseTimer < 2.5)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room3PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else if (level == 4 && pauseTimer < 2.5)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room4PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
        }
        else if (level == 5 && pauseTimer < 2.5)
        {
            doorColliders.SetActive(false);
            rockTileMap.enabled = false;
            nextRoomPause = true;
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, room5PlayerPos.position, roomTransitionSpeed * Time.deltaTime);
            rooms[4].SetActive(true);

        }
        else
        {
            doorColliders.SetActive(true);
            rockTileMap.enabled = true;
            nextRoomPause = false;
        }
    }
}
