using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCameraScript : MonoBehaviour
{
    public float speed;
    public Transform room2;
    public Transform room3;
    public Transform room4;
    public Transform room5;

    public CameraShakeScript mainCamShake;

    private void Start()
    {
        mainCamShake = FindObjectOfType<CameraShakeScript>();
    }
    void Update()
    {
        if (RoomScript.level == 2)
        {
            mainCamShake.SetNewBasePosition(room2.position);
            transform.position = Vector3.MoveTowards(transform.position, room2.position, speed * Time.deltaTime);
        }
        else if (RoomScript.level == 3)
        {
            mainCamShake.SetNewBasePosition(room3.position);
            transform.position = Vector3.MoveTowards(transform.position, room3.position, speed * Time.deltaTime);
        }
        else if (RoomScript.level == 4)
        {
            mainCamShake.SetNewBasePosition(room4.position);
            transform.position = Vector3.MoveTowards(transform.position, room4.position, speed * Time.deltaTime);
        }
        else if (RoomScript.level == 5)
        {
            mainCamShake.SetNewBasePosition(room5.position);
            transform.position = Vector3.MoveTowards(transform.position, room5.position, speed * Time.deltaTime);
        }
    }
}
