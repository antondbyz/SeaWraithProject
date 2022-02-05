using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    [Header("Build indexes")]
    [SerializeField] private int _mainMenuBuildIndex;
    [SerializeField] private int _loadingSceneBuildIndex;
    [SerializeField] private int _gameBuildIndex;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => 
        {
            SceneManager.SetActiveScene(scene);
        };
        if(SceneManager.sceneCount == 1)
        {
            OpenMainMenuScene();
        }
    }

    public void OpenMainMenuScene()
    {
        StartCoroutine(OpenScene(_mainMenuBuildIndex));
    }

    public void OpenGameScene()
    {
        StartCoroutine(OpenScene(_gameBuildIndex));
    }

    public void OpenSceneByIndex(int buildIndex)
    {
        StartCoroutine(OpenScene(buildIndex));
    }

    private IEnumerator OpenScene(int buildIndex)
    {
        for(int i = 1; i < SceneManager.sceneCount; i++)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
        }
        SceneManager.LoadScene(_loadingSceneBuildIndex, LoadSceneMode.Additive);
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        operation.allowSceneActivation = true;
        yield return new WaitUntil(() => operation.isDone);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
    }
}
