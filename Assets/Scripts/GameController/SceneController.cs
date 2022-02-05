using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void RestartScene()
    {
        ScenesManager.Instance.OpenSceneByIndex(gameObject.scene.buildIndex);
    }

    public void OpenMainMenuScene()
    {
        ScenesManager.Instance.OpenMainMenuScene();
    }

    public void OpenGameScene()
    {
        ScenesManager.Instance.OpenGameScene();
    }
}
