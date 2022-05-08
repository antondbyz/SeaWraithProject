using UnityEngine;

[RequireComponent(typeof(InterstitialAdController))]
public class GameController : SceneController
{
    public static event System.Action GameFinished;
    private InterstitialAdController _interstitialAdController;

    public void RestartCurrentSceneAfterAd()
    {
        GameFinished?.Invoke();
        _interstitialAdController.TryShowAd(() => 
        {
            RestartCurrentScene();
        });
    }

    public void OpenMainMenuSceneAfterAd()
    {
        GameFinished?.Invoke();
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
