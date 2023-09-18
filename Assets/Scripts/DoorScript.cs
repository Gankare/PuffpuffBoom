using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int removeAtLevel;
    public ParticleSystem ps;

    private void FixedUpdate()
    {
        if (RoomScript.level == removeAtLevel)
        {
            Instantiate(ps, transform.position, transform.rotation);
            Destroy(gameObject);
           
        }
    }
}
