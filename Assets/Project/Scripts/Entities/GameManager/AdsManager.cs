using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{
    public static InterstitialAd Interstitial { get; private set; }
    public static RewardedAd RewardCrystals { get; private set; }
    private const string INTERSTITIAL_ID = "ca-app-pub-4333931459484038/3828086609";
    private const string REWARD_CRYSTALS_ID = "ca-app-pub-4333931459484038/6840725038";

    public static bool ShowInterstitialAd()
    {
        if(Interstitial == null || !Interstitial.IsLoaded())
        {
            CreateAndLoadInterstitial();
            return false;
        }
        Interstitial.Show();
        return true;
    }

    public static bool ShowRewardCrystalsAd()
    {
        if(RewardCrystals == null || !RewardCrystals.IsLoaded())
        {
            CreateAndLoadCrystalsAd();
            return false;
        }
        RewardCrystals.Show();
        return true;
    } 

    private void Awake()
    {
        MobileAds.Initialize(initStatus => 
        {
            CreateAndLoadInterstitial();
            CreateAndLoadCrystalsAd();
        });
    }

    private static void CreateAndLoadInterstitial()
    {
        if(Interstitial != null) Interstitial.Destroy();
        Interstitial = new InterstitialAd(INTERSTITIAL_ID);
        Interstitial.OnAdClosed += OnInterstitialClosed;
        Interstitial.LoadAd(new AdRequest.Builder().Build());
    }

    private static void CreateAndLoadCrystalsAd()
    {
        if(RewardCrystals != null) RewardCrystals.Destroy();
        RewardCrystals = new RewardedAd(REWARD_CRYSTALS_ID);
        RewardCrystals.OnAdClosed += OnRewardCrystalsClosed;
        RewardCrystals.LoadAd(new AdRequest.Builder().Build());
    }

    #region Ads callbacks
    private static void OnInterstitialClosed(object sender, EventArgs e)
    {
        CreateAndLoadInterstitial();
    }

    private static void OnRewardCrystalsClosed(object sender, EventArgs e)
    {
        CreateAndLoadCrystalsAd();
    }
    #endregion
}
