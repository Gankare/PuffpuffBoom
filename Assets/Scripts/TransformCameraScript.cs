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
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(room2.position.x, room2.position.y, -10), speed * Time.deltaTime);
        }
        else if (RoomScript.level == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(room3.position.x, room3.position.y, -10), speed * Time.deltaTime);
        }
        else if (RoomScript.level == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(room4.position.x, room4.position.y, -10), speed * Time.deltaTime);
        }
    }
}
