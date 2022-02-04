using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void RestartScene()
    {
        StartCoroutine(ScenesManager.Instance.OpenScene(gameObject.scene.buildIndex));
    }

    public void OpenMainMenuScene()
    {
        StartCoroutine(ScenesManager.Instance.OpenScene(ScenesManager.Instance.MainMenuBuildIndex));
    }

    public void OpenGameScene()
    {
        StartCoroutine(ScenesManager.Instance.OpenScene(ScenesManager.Instance.GameBuildIndex));
    }
}
