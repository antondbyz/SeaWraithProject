using UnityEngine;

[RequireComponent(typeof(InterstitialAdController))]
public class GameController : SceneController
{
    private InterstitialAdController _interstitialAdController;

    public void RestartCurrentSceneAfterAd()
    {
        _interstitialAdController.TryShowAd(() => 
        {
            RestartCurrentScene();
        });
    }

    public void OpenMainMenuSceneAfterAd()
    {
        _interstitialAdController.TryShowAd(() => 
        {
            OpenMainMenuScene();
        });
    }

    private void Awake()
    {
        _interstitialAdController = GetComponent<InterstitialAdController>();
    }
}
