using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void RestartCurrentScene()
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
