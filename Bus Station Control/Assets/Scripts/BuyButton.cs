using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        

        NoAds
    }

    public ItemType itemType;

    

    private string defaultText;
    void Start()
    {
        
        StartCoroutine(LoadPriceRoutine());
    }

   public void Clickbuy()
    {
        switch (itemType)
        {
            

            case ItemType.NoAds:
                break; 
        }
    }

   
    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
        {
            yield return null;
        }

        string loadedPrice = "";
        switch (itemType)
        {
            
            case ItemType.NoAds:
               loadedPrice= IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.NO_ADS);
                break;

        }

        
    }
}
