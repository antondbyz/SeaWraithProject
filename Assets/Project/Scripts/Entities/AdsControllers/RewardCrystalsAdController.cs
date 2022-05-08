using System;
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
        AdsManager.RewardCrystalsLoaded -= OnAdLoaded;
        AdsManager.RewardCrystalsFailedToLoad -= OnAdFailedToLoad;
        _adFailedToLoadLabel.SetActive(false);
        bool showAdSuccessStatus = AdsManager.Instance.ShowRewardCrystalsAd();
        if(showAdSuccessStatus)
        {
            AdsManager.RewardCrystalsEarnedReward += EarnedReward;
            AdsManager.RewardCrystalsClosed += OnAdClosed;
        }
        else
        {
            AdsManager.RewardCrystalsLoaded += OnAdLoaded;
            AdsManager.RewardCrystalsFailedToLoad += OnAdFailedToLoad;
            _showAdButton.SetActive(false);
            _adLoadingLabel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        AdsManager.RewardCrystalsLoaded -= OnAdLoaded;
        AdsManager.RewardCrystalsFailedToLoad -= OnAdFailedToLoad;
        AdsManager.RewardCrystalsEarnedReward -= EarnedReward;
        AdsManager.RewardCrystalsClosed -= OnAdClosed;
    }

    private void OnAdClosed()
    {
        _adClosed.Invoke();
    }

    private void OnAdLoaded()
    {
        TryShowAd();
    }

    private void OnAdFailedToLoad()
    {
        _adFailedToLoadLabel.SetActive(true);
        _showAdButton.SetActive(true);
        _adLoadingLabel.SetActive(false);
    }
}
