using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void RestartScene()
    {
        ScenesManager.Instance.OpenGameScene();
    }
}
