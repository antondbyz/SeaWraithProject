using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    public int MainMenuBuildIndex => _mainMenuBuildIndex;
    public int LoadingSceneBuildIndex => _loadingSceneBuildIndex;
    public int GameBuildIndex => _gameBuildIndex;

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
            StartCoroutine(OpenScene(_mainMenuBuildIndex));
        }
    }

    public IEnumerator OpenScene(int buildIndex)
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
        if(!operation.isDone) yield return operation;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
    }
}
