using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class RoomScript : MonoBehaviour
{
    public static int level;
    public static int enemiesDead;
    public GameObject[] rooms;

    private void FixedUpdate()
    {
        if (level == 1 && enemiesDead >= 1)
        {
            level = 2; 
            enemiesDead = 0;
        }
        else if (level == 2 && enemiesDead >= 2)
        {
            level = 3;
            enemiesDead = 0;
        }
        else if (level == 3 && enemiesDead >= 3)
        {
            level = 4;
            enemiesDead = 0;
        }
        else if (level == 4 && enemiesDead >= 4)
        {
            //Spawn boss or win game
        }

        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
        for (int i = 0; i <= level; i++)
        {
            rooms[i].SetActive(true);
        }
    }
}
