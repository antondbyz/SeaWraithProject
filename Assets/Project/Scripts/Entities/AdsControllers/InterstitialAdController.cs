using System;
using UnityEngine;

public class InterstitialAdController : MonoBehaviour
{
    private Action _adClosedAction;

    public void TryShowAd(Action adClosedAction)
    {
        _adClosedAction = adClosedAction;
        bool showAdSuccessStatus = AdsManager.Instance.ShowInterstitialAd();
        if(showAdSuccessStatus)
        {
            AdsManager.InterstitialClosed += _adClosedAction;
        }
        else
        {
            _adClosedAction.Invoke();
        }
    }

    private void OnDisable()
    {
        AdsManager.InterstitialClosed -= _adClosedAction;
    }
}
