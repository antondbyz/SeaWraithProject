using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;

public class RewardCrystalsAdController : MonoBehaviour
{
    public static event Action EarnedReward;
    [SerializeField] private GameObject _showAdButton;
    [SerializeField] private GameObject _adLoadingLabel;
    [SerializeField] private GameObject _adFailedToLoadLabel;
    [SerializeField] private UnityEvent _adClosed;

    public void TryShowAd()
    {
        AdsManager.RewardCrystals.OnAdLoaded -= OnAdLoaded;
        AdsManager.RewardCrystals.OnAdFailedToLoad -= OnAdFailedToLoad;
        _adFailedToLoadLabel.SetActive(false);
        bool showAdSuccessStatus = AdsManager.ShowRewardCrystalsAd();
        if(showAdSuccessStatus)
        {
            AdsManager.RewardCrystals.OnUserEarnedReward += OnEarnedReward;
            AdsManager.RewardCrystals.OnAdClosed += OnAdClosed;
        }
        else
        {
            AdsManager.RewardCrystals.OnAdLoaded += OnAdLoaded;
            AdsManager.RewardCrystals.OnAdFailedToLoad += OnAdFailedToLoad;
            _showAdButton.SetActive(false);
            _adLoadingLabel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        AdsManager.RewardCrystals.OnAdLoaded -= OnAdLoaded;
        AdsManager.RewardCrystals.OnAdFailedToLoad -= OnAdFailedToLoad;
        AdsManager.RewardCrystals.OnUserEarnedReward -= OnEarnedReward;
            AdsManager.RewardCrystals.OnAdClosed -= OnAdClosed;
    }

    private void OnAdClosed(object sender, EventArgs e)
    {
        _adClosed.Invoke();
    }

    private void OnAdLoaded(object sender, EventArgs e)
    {
        TryShowAd();
    }

    private void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        _adFailedToLoadLabel.SetActive(true);
        _showAdButton.SetActive(true);
        _adLoadingLabel.SetActive(false);
    }

    private void OnEarnedReward(object sender, Reward e)
    {
        EarnedReward?.Invoke();
    }
}
