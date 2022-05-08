using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : Singleton<AdsManager>
{
    #region Ads events
    public static event System.Action InterstitialClosed;
    public static event System.Action RewardCrystalsClosed;
    public static event System.Action RewardCrystalsLoaded;
    public static event System.Action RewardCrystalsFailedToLoad;
    public static event System.Action RewardCrystalsEarnedReward;
    #endregion
    private static InterstitialAd _interstitial;
    private static RewardedAd _rewardCrystals;
    private const string INTERSTITIAL_ID = "ca-app-pub-4333931459484038/5717006129";
    private const string REWARD_CRYSTALS_ID = "ca-app-pub-4333931459484038/1586189428";
    private static WaitForSecondsRealtime adsCallbacksDelay = new WaitForSecondsRealtime(0.1f);

    public bool ShowInterstitialAd()
    {
        if(_interstitial == null || !_interstitial.IsLoaded())
        {
            CreateAndLoadInterstitial();
            return false;
        }
        _interstitial.Show();
        return true;
    }

    public bool ShowRewardCrystalsAd()
    {
        if(_rewardCrystals == null || !_rewardCrystals.IsLoaded())
        {
            CreateAndLoadCrystalsAd();
            return false;
        }
        _rewardCrystals.Show();
        return true;
    } 

    protected override void Awake()
    {
        base.Awake();
        MobileAds.Initialize(initStatus => 
        {
            CreateAndLoadInterstitial();
            CreateAndLoadCrystalsAd();
        });
    }

    private void CreateAndLoadInterstitial()
    {
        if(_interstitial != null) _interstitial.Destroy();
        _interstitial = new InterstitialAd(INTERSTITIAL_ID);
        _interstitial.OnAdClosed += OnInterstitialClosed;
        _interstitial.LoadAd(new AdRequest.Builder().Build());
    }

    private void CreateAndLoadCrystalsAd()
    {
        if(_rewardCrystals != null) _rewardCrystals.Destroy();
        _rewardCrystals = new RewardedAd(REWARD_CRYSTALS_ID);
        _rewardCrystals.OnAdClosed += OnRewardCrystalsClosed;
        _rewardCrystals.OnAdLoaded += OnRewardCrystalsLoaded;
        _rewardCrystals.OnAdFailedToLoad += OnRewardCrystalsFailedToLoad;
        _rewardCrystals.OnUserEarnedReward += OnRewardCrystalsEarnedReward;
        _rewardCrystals.LoadAd(new AdRequest.Builder().Build());
    }

    #region Ads callbacks
    private void OnInterstitialClosed(object sender, EventArgs e)
    {
        StartCoroutine(Helper.DoAfterDelay(adsCallbacksDelay, () => 
        {
            CreateAndLoadInterstitial();
            InterstitialClosed?.Invoke();
        }));
    }

    private void OnRewardCrystalsClosed(object sender, EventArgs e)
    {
        StartCoroutine(Helper.DoAfterDelay(adsCallbacksDelay, () => 
        {
            CreateAndLoadCrystalsAd();
            RewardCrystalsClosed?.Invoke();
        }));
    }
    
    private void OnRewardCrystalsLoaded(object sender, EventArgs e)
    {
        StartCoroutine(Helper.DoAfterDelay(adsCallbacksDelay, RewardCrystalsLoaded));
    }

    private void OnRewardCrystalsFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        StartCoroutine(Helper.DoAfterDelay(adsCallbacksDelay, RewardCrystalsFailedToLoad));
    }

    private void OnRewardCrystalsEarnedReward(object sender, Reward e)
    {
        StartCoroutine(Helper.DoAfterDelay(adsCallbacksDelay, RewardCrystalsEarnedReward));
    }
    #endregion
}
