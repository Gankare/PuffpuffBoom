using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class RoomScript : MonoBehaviour
{
    public static int level;
    public GameObject[] rooms;

    private void FixedUpdate()
    {
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
