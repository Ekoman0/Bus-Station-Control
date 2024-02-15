using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{


    private string _adUnitId = "ca-app-pub-3138384441939461/2925222565";


    BannerView _bannerView;

    private void Awake()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

            // This callback is called once the MobileAds SDK is initialized.
        });
        if (PlayerPrefs.HasKey("Ads"))
        {
            if (PlayerPrefs.GetInt("Ads") == 1)
            {

            }
            if (PlayerPrefs.GetInt("Ads") == 0)
            {
                LoadAd();
            }
        }
        else
        {
            LoadAd();
        }
        
    }
    public void Start()
    {
        
    }


    public void CreateBannerView()
    {
        
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
    }

    public void LoadAd()
    {
       
            
            CreateBannerView();
        
        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        
        _bannerView.LoadAd(adRequest);
    }

   
}