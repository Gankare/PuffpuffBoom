
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomScript : MonoBehaviour
{
    public static int currentLevel;

    public static bool nextRoomPause;
    public float roomTransitionSpeed;
    private Transform playerTransform;

    private GameObject doorCollider;
    private TilemapCollider2D rockTileMapCollider;

    public GameObject[] enemies;
    public List<GameObject> enemieList = new List<GameObject>();

    public Transform[] nextRoomPos;
    public GameObject[] rooms;
    void Start()
    {
        currentLevel = 0;
        nextRoomPause = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rockTileMapCollider = GameObject.Find("Rocks").GetComponent<TilemapCollider2D>();
        doorCollider = GameObject.Find("DoorColliders");
        UpdateEnemies();
    }

    private void FixedUpdate()
    {
        RemoveEnemyFromList();
    }
    void Update()
    {
        if (enemieList.Count == 0 && !nextRoomPause) //Checks if all enemies are dead
        {
            StartCoroutine(LoadNewLevel());
        }
        if(nextRoomPause) //Moves the player to next level while paused/waiting for next room
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.transform.position, nextRoomPos[currentLevel - 1].position, roomTransitionSpeed * Time.deltaTime);
        }
    }
    public void RemoveEnemyFromList() //Removes dead enemies from list
    {
        enemieList.RemoveAll(nullEnemies => nullEnemies == null);
    }
    IEnumerator LoadNewLevel() //Readys the next room, spawning enemies and putting them in a list, removing colliders while player is paused and then adding them back when in new room
    {
        currentLevel += 1;
        rooms[currentLevel].SetActive(true);
        doorCollider.SetActive(false);
        rockTileMapCollider.enabled = false;
        nextRoomPause = true;
        yield return new WaitForSeconds(0.5f);
        UpdateEnemies();
        yield return new WaitForSeconds(2);
        nextRoomPause = false;
        doorCollider.SetActive(true);
        rockTileMapCollider.enabled = true;
    }
    public void UpdateEnemies() //Adds the alive enemies to enemylist
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
                enemieList.Add(enemy);
        }
    }
}