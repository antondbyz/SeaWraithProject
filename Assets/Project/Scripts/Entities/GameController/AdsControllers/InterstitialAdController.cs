using System;
using UnityEngine;

public class InterstitialAdController : MonoBehaviour
{
    private Action _afterAdAction;

    public void TryShowAd(Action afterAdAction)
    {
        _afterAdAction = afterAdAction;
        bool showAdSuccessStatus = AdsManager.ShowInterstitialAd();
        if(!showAdSuccessStatus)
        {
            _afterAdAction?.Invoke();
        }
        else
        {
            AdsManager.Interstitial.OnAdClosed += OnAdClosed;
        }
    }

    private void OnDisable()
    {
        AdsManager.Interstitial.OnAdClosed -= OnAdClosed;
    }

    private void OnAdClosed(object sender, EventArgs e)
    {
        _afterAdAction?.Invoke();
    }
}
