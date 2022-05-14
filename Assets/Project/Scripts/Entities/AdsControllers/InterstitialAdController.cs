using System;
using UnityEngine;

public class InterstitialAdController : MonoBehaviour
{
    private Action _afterAdAction;
    private bool _isEarnedReward;

    public void TryShowAd(Action afterAdAction)
    {
        _afterAdAction = afterAdAction;
        if(_isEarnedReward) 
        {
            _afterAdAction?.Invoke();
            return;
        }
        bool showAdSuccessStatus = AdsManager.Instance.ShowInterstitialAd();
        if(showAdSuccessStatus)
        {
            AdsManager.InterstitialClosed += _afterAdAction;
        }
        else
        {
            _afterAdAction?.Invoke();
        }
    }

    private void OnEnable()
    {
        RewardCrystalsAdController.EarnedReward += OnEarnedReward;
    }

    private void OnDisable()
    {
        AdsManager.InterstitialClosed -= _afterAdAction;
        RewardCrystalsAdController.EarnedReward -= OnEarnedReward;
    }

    private void OnEarnedReward() => _isEarnedReward = true;
}
