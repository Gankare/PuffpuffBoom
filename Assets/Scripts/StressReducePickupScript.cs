using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressReducePickupScript : MonoBehaviour
{

    public int amountToDestress;
    private AudioSource eatSound;

    private void Start()
    {
        eatSound = GameObject.Find("KrillSound").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            eatSound.Play();
            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(-amountToDestress);
            Destroy(this.gameObject);
        }
    }
}
