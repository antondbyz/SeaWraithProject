using System.Collections;
using UnityEngine;

public static class Helper
{
    public static IEnumerator DoAfterDelay(IEnumerator instruction, System.Action action)
    {
        yield return instruction;
        action?.Invoke();
    }
}

[System.Serializable]
public struct MinMaxRange<T>
{
    public T Min;
    public T Max;
}

public static class ObjectsFinder
{
    public static GameObject FindPlayer() => GameObject.FindWithTag("Player");

    public static GameObject FindGameController() => GameObject.FindWithTag("GameController");
}
