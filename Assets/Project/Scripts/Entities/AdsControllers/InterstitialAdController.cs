using System;
using UnityEngine;

public class InterstitialAdController : MonoBehaviour
{
    private Action _adClosedAction;

    public void TryShowAd(Action adClosedAction)
    {
        _adClosedAction = adClosedAction;
        bool showAdSuccessStatus = AdsManager.ShowInterstitialAd();
        if(showAdSuccessStatus)
        {
            AdsManager.Interstitial.OnAdClosed += OnAdClosed;
        }
        else
        {
            _adClosedAction.Invoke();
        }
    }

    private void OnDisable()
    {
        AdsManager.Interstitial.OnAdClosed -= OnAdClosed;
    }

    private void OnAdClosed(object sender, EventArgs e)
    {
        _adClosedAction.Invoke();
    }
}
