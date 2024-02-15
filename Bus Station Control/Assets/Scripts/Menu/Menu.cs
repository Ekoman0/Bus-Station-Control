using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject LvlMenu;
    public GameObject MainMenuButton;

    public Sprite MuteSprite;
    public Sprite UnMuteSprite;
    public Button MuteButton;
    bool mute = false;


    public Button lvl2BTN;
    public Button lvl3BTN;
    public Button lvl4BTN;
    public Button lvl5BTN;
    public Button lvl6BTN;
    public Button lvl7BTN;
    public Button lvl8BTN;
    public Button lvl9BTN;
    public Button lvl10BTN;
    public Button lvl11BTN;
    public Button lvl12BTN;
    public Button lvl13BTN;
    public Button lvl14BTN;
    public Button lvl15BTN;
    public Button lvl16BTN;
    public Button lvl17BTN;
    public Button lvl18BTN;

    public GameObject lvl2LOCK;
    public GameObject lvl3LOCK;
    public GameObject lvl4LOCK;
    public GameObject lvl5LOCK;
    public GameObject lvl6LOCK;
    public GameObject lvl7LOCK;
    public GameObject lvl8LOCK;
    public GameObject lvl9LOCK;
    public GameObject lvl10LOCK;
    public GameObject lvl11LOCK;
    public GameObject lvl12LOCK;
    public GameObject lvl13LOCK;
    public GameObject lvl14LOCK;
    public GameObject lvl15LOCK;
    public GameObject lvl16LOCK;
    public GameObject lvl17LOCK;
    public GameObject lvl18LOCK;

    private void Start()
    {
        LvlComplete();
    }
    public void PlayButton()
    {     
        GameObject[] Trucks = GameObject.FindGameObjectsWithTag("Truck");
        for (int i = 0; i < Trucks.Length; i++)
        {
            Destroy(Trucks[i]);
            
        }

        LvlMenu.SetActive(true);
        MainMenuButton.SetActive(false);
        this.gameObject.GetComponent<MenuTruckSpawner>().enabled = false;
    }

    public void MuteButtonevnt()
    {
        if (mute == false)
        {
            MuteButton.GetComponent<Image>().sprite = MuteSprite;
            AudioListener.volume = 0;
            mute = true;
        }
        else
        {
            MuteButton.GetComponent<Image>().sprite = UnMuteSprite;
            AudioListener.volume = 1;
            mute = false ;

        }
    }

    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }

    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }
    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }
    public void Lvl4()
    {
        SceneManager.LoadScene(4);
    }
    public void Lvl5()
    {
        SceneManager.LoadScene(5);
    }
    public void Lvl6()
    {
        SceneManager.LoadScene(6);
    }
    public void Lvl7()
    {
        SceneManager.LoadScene(7);
    }
    public void Lvl8()
    {
        SceneManager.LoadScene(8);
    }
    public void Lvl9()
    {
        SceneManager.LoadScene(9);
    }
    public void Lvl10()
    {
        SceneManager.LoadScene(10);
    }
    public void Lvl11()
    {
        SceneManager.LoadScene(11);
    }
    public void Lvl12()
    {
        SceneManager.LoadScene(12);
    }
    public void Lvl13()
    {
        SceneManager.LoadScene(13);
    }
    public void Lvl14()
    {
        SceneManager.LoadScene(14);
    }
    public void Lvl15()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl16()
    {
        SceneManager.LoadScene(16);
    }
    public void Lvl17()
    {
        SceneManager.LoadScene(17);
    }
    public void Lvl18()
    {
        SceneManager.LoadScene(18);
    }







    private void LvlComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (PlayerPrefs.HasKey("Lvl1"))
        {
            if (PlayerPrefs.GetInt("Lvl1") == 1)
            {
                lvl2BTN.enabled = true;
                lvl2LOCK.SetActive(false);
            }
           
        }
        else
        {
            lvl2BTN.enabled = false;
            lvl2LOCK.SetActive(true);

        }

        if (PlayerPrefs.HasKey("Lvl2"))
        {
            if (PlayerPrefs.GetInt("Lvl2") == 1)
            {
                lvl3BTN.enabled = true;
                lvl3LOCK.SetActive(false);
            }
           
        }
        else
        {
            lvl3BTN.enabled = false;
            lvl3LOCK.SetActive(true);
        }


        if (PlayerPrefs.HasKey("Lvl3"))
        {
            if (PlayerPrefs.GetInt("Lvl3") == 1)
            {
                lvl4BTN.enabled = true;
                lvl4LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl4BTN.enabled = false;
            lvl4LOCK.SetActive(true);
        }


        if (PlayerPrefs.HasKey("Lvl4"))
        {
            if (PlayerPrefs.GetInt("Lvl4") == 1)
            {
                lvl5BTN.enabled = true;
                lvl5LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl5BTN.enabled = false;
            lvl5LOCK.SetActive(true);
        }


        if (PlayerPrefs.HasKey("Lvl5"))
        {
            if (PlayerPrefs.GetInt("Lvl5") == 1)
            {
                lvl6BTN.enabled = true;
                lvl6LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl6BTN.enabled = false;
            lvl6LOCK.SetActive(true);

        }


        if (PlayerPrefs.HasKey("Lvl6"))
        {
            if (PlayerPrefs.GetInt("Lvl6") == 1)
            {
                lvl7BTN.enabled = true;
                lvl7LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl7BTN.enabled = false;
            lvl7LOCK.SetActive(true);
        }


        if (PlayerPrefs.HasKey("Lvl7"))
        {
            if (PlayerPrefs.GetInt("Lvl7") == 1)
            {
                lvl8BTN.enabled = true;
                lvl8LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl8BTN.enabled = false;
            lvl8LOCK.SetActive(true);
        }


        if (PlayerPrefs.HasKey("Lvl8"))
        {
            if (PlayerPrefs.GetInt("Lvl8") == 1)
            {
                lvl9BTN.enabled = true;
                lvl9LOCK.SetActive(false);
            }
            
        }
        else
        {
            lvl9BTN.enabled = false;
            lvl9LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl9"))
        {
            if (PlayerPrefs.GetInt("Lvl9") == 1)
            {
                lvl10BTN.enabled = true;
                lvl10LOCK.SetActive(false);
            }

        }
        else
        {
            lvl10BTN.enabled = false;
            lvl10LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl10"))
        {
            if (PlayerPrefs.GetInt("Lvl10") == 1)
            {
                lvl11BTN.enabled = true;
                lvl11LOCK.SetActive(false);
            }

        }
        else
        {
            lvl11BTN.enabled = false;
            lvl11LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl11"))
        {
            if (PlayerPrefs.GetInt("Lvl11") == 1)
            {
                lvl12BTN.enabled = true;
                lvl12LOCK.SetActive(false);
            }

        }
        else
        {
            lvl12BTN.enabled = false;
            lvl12LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl12"))
        {
            if (PlayerPrefs.GetInt("Lvl12") == 1)
            {
                lvl13BTN.enabled = true;
                lvl13LOCK.SetActive(false);
            }

        }
        else
        {
            lvl13BTN.enabled = false;
            lvl13LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl13"))
        {
            if (PlayerPrefs.GetInt("Lvl13") == 1)
            {
                lvl14BTN.enabled = true;
                lvl14LOCK.SetActive(false);
            }

        }
        else
        {
            lvl14BTN.enabled = false;
            lvl14LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl14"))
        {
            if (PlayerPrefs.GetInt("Lvl14") == 1)
            {
                lvl15BTN.enabled = true;
                lvl15LOCK.SetActive(false);
            }

        }
        else
        {
            lvl15BTN.enabled = false;
            lvl15LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl15"))
        {
            if (PlayerPrefs.GetInt("Lvl15") == 1)
            {
                lvl16BTN.enabled = true;
                lvl16LOCK.SetActive(false);
            }

        }
        else
        {
            lvl16BTN.enabled = false;
            lvl16LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl16"))
        {
            if (PlayerPrefs.GetInt("Lvl16") == 1)
            {
                lvl17BTN.enabled = true;
                lvl17LOCK.SetActive(false);
            }

        }
        else
        {
            lvl17BTN.enabled = false;
            lvl17LOCK.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Lvl17"))
        {
            if (PlayerPrefs.GetInt("Lvl17") == 1)
            {
                lvl18BTN.enabled = true;
                lvl18LOCK.SetActive(false);
            }

        }
        else
        {
            lvl18BTN.enabled = false;
            lvl18LOCK.SetActive(true);
        }

    }
}
