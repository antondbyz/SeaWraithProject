using UnityEngine;

[System.Serializable]
public struct MinMaxRange<T>
{
    public T Min;
    public T Max;
}

public static class ObjectsFinder
{
    public static GameObject FindPlayer() => GameObject.FindWithTag("Player");
}
