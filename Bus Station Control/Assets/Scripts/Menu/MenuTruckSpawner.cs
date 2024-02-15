using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTruckSpawner : MonoBehaviour
{
    public GameObject Truck;
    float Timer;
    float Timer1;

    public GameObject Start;
    public GameObject Start1;
    
    private void Update()
    {
        if (Timer<0)
        {
            Instantiate(Truck,Start.transform.position,Quaternion.identity);
            Timer = Random.Range(0.5f,4f);
        }
        Timer -= Time.deltaTime;

        if (Timer1 < 0)
        {
            Instantiate(Truck, Start1.transform.position, Quaternion.identity);
            Timer1 = Random.Range(0.5f, 4f);
        }
        Timer1 -= Time.deltaTime;
    }
}
