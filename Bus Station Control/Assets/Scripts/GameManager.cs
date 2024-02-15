using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public List<GameObject> Trucks;
    

    public TextMeshProUGUI MoneyTMP;
    public Image[] HearthImg;

    public float Hearth = 3;
    public int Money;
    public GameObject Instertitial;
    
    public GameObject GameFinish;
    public GameObject GameComplete;
    public GameObject GamePaused;
    private float ADtimer = 10f;
    private bool AdBool=false;
    private bool Paused;

    public int RemainingTruck=10;
    private void Awake()
    {
        GameComplete.SetActive(false);
        GamePaused.SetActive(false);
        GameFinish.SetActive(false);
        HearthUI();
    }
    private void Update()
    {
        MoneyTMP.text = Money.ToString();
        if (Hearth <= 0)
        {
            if (ADtimer <=10f)
            {
                Instertitial.GetComponent<Instertitial>().ShowAd();
            }
            ADtimer += 1;
            
            Time.timeScale = 0;
            GameFinish.SetActive(true);

            
        }
        else
        {
            ADtimer = 10f;
            if (Paused == false)
            {
                Time.timeScale = 1;
            }
            
            GameFinish.SetActive(false);
        }
        if (RemainingTruck <= 0)
        {
            GameObject[] truckObjects = GameObject.FindGameObjectsWithTag("Truck");
            Trucks = new List<GameObject>(truckObjects);
            if (Trucks.Count <= 0)
            {
                //oyunu kazandýn
                if (AdBool == false)
                {
                    Instertitial.GetComponent<Instertitial>().ShowAd();
                    AdBool = true;
                }
                
                LvlComplete();
                GameComplete.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {  
                Trucks.RemoveAll(s => s == null);
                AdBool = false;
                
            }
        }
    }

    public void HearthUI()
    {
        for (int i = 3; i > Hearth; i--)
        {
            HearthImg[i -1].enabled = false;
        }
    }
    public void HearthUITrue()
    {
        for (int i = 0; i < Hearth; i++)
        {
            HearthImg[i].enabled = true;
        }
    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LvlPause()
    {
        Paused = true;
        Time.timeScale = 0;
        GamePaused.SetActive(true);
    }
    public void LvlResume()
    {
        Paused = false;
        GamePaused.SetActive(false);
        Time.timeScale = 1;
    }
    public void LvlRetry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        SceneManager.LoadScene(sceneName);
    }
    private void LvlComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Lvl1")
        {
            PlayerPrefs.SetInt("Lvl1", 1);
        }

        else if (sceneName == "Lvl2")
        {
            PlayerPrefs.SetInt("Lvl2", 1);
        }

        else if (sceneName == "Lvl3")
        {
            PlayerPrefs.SetInt("Lvl3", 1);
        }

        else if (sceneName == "Lvl4")
        {
            PlayerPrefs.SetInt("Lvl4", 1);
        }

        else if (sceneName == "Lvl5")
        {
            PlayerPrefs.SetInt("Lvl5", 1);
        }

        else if (sceneName == "Lvl6")
        {
            PlayerPrefs.SetInt("Lvl6", 1);
        }

        else if (sceneName == "Lvl7")
        {
            PlayerPrefs.SetInt("Lvl7", 1);
        }

        else if (sceneName == "Lvl8")
        {
            PlayerPrefs.SetInt("Lvl8", 1);

        }
        else if (sceneName == "Lvl9")
        {
            PlayerPrefs.SetInt("Lvl9", 1);

        }
        else if (sceneName == "Lvl10")
        {
            PlayerPrefs.SetInt("Lvl10", 1);

        }
        else if (sceneName == "Lvl11")
        {
            PlayerPrefs.SetInt("Lvl11", 1);

        }
        else if (sceneName == "Lvl12")
        {
            PlayerPrefs.SetInt("Lvl12", 1);

        }
        else if (sceneName == "Lvl13")
        {
            PlayerPrefs.SetInt("Lvl13", 1);

        }
        else if (sceneName == "Lvl14")
        {
            PlayerPrefs.SetInt("Lvl14", 1);

        }
        else if (sceneName == "Lvl15")
        {
            PlayerPrefs.SetInt("Lvl15", 1);

        }
        else if (sceneName == "Lvl16")
        {
            PlayerPrefs.SetInt("Lvl16", 1);

        }
        else if (sceneName == "Lvl17")
        {
            PlayerPrefs.SetInt("Lvl17", 1);

        }
        else if (sceneName == "Lvl18")
        {
            PlayerPrefs.SetInt("Lvl18", 1);

        }
    }
}
