using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckStop : MonoBehaviour
{
    public bool TruckStoped = false;
 
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            
            TruckStoped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            
            TruckStoped = false;
        }
    }
}
