using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int OpenAtLevel;
    private bool doorOpened = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (RoomScript.level == OpenAtLevel && !doorOpened)
        {
            animator.SetTrigger("Open");
            doorOpened = true;
        }
    }
}
