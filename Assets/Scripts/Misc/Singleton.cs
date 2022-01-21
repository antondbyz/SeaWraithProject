using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T Instance;

    protected virtual void Awake()
    {
        if(Instance == null) Instance = GetComponent<T>();
        else Debug.LogWarning("More than one instance of " + typeof(T));
    }
}
