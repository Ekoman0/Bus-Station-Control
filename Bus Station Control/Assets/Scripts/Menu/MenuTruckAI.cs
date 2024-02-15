using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTruckAI : MonoBehaviour
{
    private GameObject End;
    private GameObject End1;

    bool MenuStart;
    bool MenuStart1;

    private float speed = 2;

    private void Awake()
    {
        End = GameObject.FindGameObjectWithTag("MenuEnd");
        End1 = GameObject.FindGameObjectWithTag("MenuEnd1");
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="MenuStart")
        {
            MenuStart = true;
        }
        else if (collision.gameObject.tag == "MenuStart1")
        {
            MenuStart1 = true;
        }

        if (collision.gameObject.tag == "MenuEnd" || collision.gameObject.tag == "MenuEnd1")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (MenuStart == true)
        {
            // hedef objenin pozisyonunu ve kendi pozisyonunu al
            Vector3 targetPos = End.transform.position;
            Vector3 selfPos = transform.position;

            // hedef objeye doðru bak
            transform.up = targetPos - selfPos;

            // objeyi hedef objeye doðru hareket ettir
            transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
        }
        else if (MenuStart1 == true)
        {
            // hedef objenin pozisyonunu ve kendi pozisyonunu al
            Vector3 targetPos = End1.transform.position;
            Vector3 selfPos = transform.position;

            // hedef objeye doðru bak
            transform.up = targetPos - selfPos;

            // objeyi hedef objeye doðru hareket ettir
            transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
        }
        
    }
}
