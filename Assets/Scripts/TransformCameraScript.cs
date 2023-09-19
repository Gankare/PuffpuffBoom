using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCameraScript : MonoBehaviour
{
    public float speed;
    public Transform room2;
    public Transform room3;
    public Transform room4;

    void Update()
    {
        if (RoomScript.level == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, room2.position, speed * Time.deltaTime);
        }
        else if (RoomScript.level == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, room3.position, speed * Time.deltaTime);
        }
        else if (RoomScript.level == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, room4.position, speed * Time.deltaTime);
        }
    }
}
