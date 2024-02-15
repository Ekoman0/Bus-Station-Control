using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Station : MonoBehaviour
{
    
    private GameObject GameManager;
    public bool isLock;

    public float WorkTimer= 7f;
    public Button UpdateButton;
    public int UpdatePrice = 250;
    public int UpdateStatus=0;
    public int MaxUpdateStatus;

    public Image[] UpgradeImage;
    public Sprite UpgradedImage;

    public GameObject LockImage;
    public GameObject LockBackgroundCanvas;
    public Button LockButton;
    public int LockPrice = 200;
    public GameObject LockMoneyEnough;
    public TextMeshProUGUI LockMoneyTxt;



    void Start()
    {
        if (isLock == true)
        {
            LockMoneyTxt.text = "Pay "+ LockPrice +" coýns to Unlock";
            LockBackgroundCanvas.SetActive(true);
            LockImage.SetActive(true);
            LockButton.enabled = true;
            CloseLock();
        }
        
        GameManager = GameObject.Find("GameManager");
        UpdateButton.enabled = false;
        UpdateButton.image.enabled = false;

        for (int i = 3; i > MaxUpdateStatus; i--)
        {
            UpgradeImage[i -1].enabled = false;
        }

    }

    void Update()
    {
        if (GameManager.GetComponent<GameManager>().Money >= UpdatePrice && UpdateStatus < MaxUpdateStatus && isLock == false)
        {
            UpdateButton.enabled = true;
            UpdateButton.image.enabled = true;
        }
        else
        {
            
            UpdateButton.image.enabled = false;
            UpdateButton.enabled = false;
        }
    }

    public void UpdateFonk()
    {
        
        if (GameManager.GetComponent<GameManager>().Money >= UpdatePrice && UpdateStatus < MaxUpdateStatus)
        {
            GameManager.GetComponent<GameManager>().Money -= UpdatePrice;
            UpdateStatus += 1;
            for (int i = 0; i < UpdateStatus; i++)
            {
                UpgradeImage[i].GetComponent<Image>().sprite= UpgradedImage;
            }
            UpdatePrice *= 2;
            WorkTimer -= 1f;
        }
    }

    public void PressLock()
    {
        
            Time.timeScale = 0;
            LockMoneyEnough.SetActive(true);
        
       
       
    }
    public void OpenLock()
    {
        if (GameManager.GetComponent<GameManager>().Money >= LockPrice && isLock == true)
        {
            GameManager.GetComponent<GameManager>().Money -= LockPrice;
            LockBackgroundCanvas.SetActive(false);
            LockImage.SetActive(false);
            LockButton.enabled = false;
            isLock = false;
            CloseLock();
        }
    }
    public void CloseLock()
    {
        LockMoneyEnough.SetActive(false);
        
        Time.timeScale = 1;
    }
}
