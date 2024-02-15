using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool TruckIn = false;
    public GameObject OtherPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            if (TruckIn == false)
            {
                collision.gameObject.GetComponent<Controller>().InPortal = true;

                collision.gameObject.transform.position = new Vector3(OtherPortal.transform.position.x, OtherPortal.transform.position.y, collision.gameObject.transform.position.z);
                OtherPortal.GetComponent<Portal>().TruckIn = true;
            }
            
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            if (TruckIn == true)
            {
                TruckIn = false;
                OtherPortal.GetComponent<Portal>().TruckIn = false;
            }


        }
    }


}
