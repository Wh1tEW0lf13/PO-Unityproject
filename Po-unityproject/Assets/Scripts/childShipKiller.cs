using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//klasa stworzona w celu dodania drugiego colidera do Ship killera
public class childShipKiller : MonoBehaviour
{
    //collider rozszerzony - spelnia fnkcje radaru i namierzania bliskich statkow
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==6)
        {
            if (collision.gameObject.CompareTag(transform.parent.GetComponent<ShipKiller>().enemyTag) && collision.gameObject.GetComponent<PoorShip>().isMining == false)
            {
                print("detect");
                transform.parent.GetComponent<ShipKiller>().followedShip = collision.gameObject;
                transform.parent.GetComponent<ShipKiller>().isFollowing = true;
            }
        }
        
    }
    
}

