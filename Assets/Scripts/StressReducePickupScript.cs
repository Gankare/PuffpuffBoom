using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressReducePickupScript : MonoBehaviour
{

    public int amountToDestress;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<StressScript>().ChangeStressAmount(-amountToDestress);
            Destroy(this.gameObject);
        }
    }
}
