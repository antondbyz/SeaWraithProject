using UnityEngine;

[System.Serializable]
struct MinMaxRange<T>
{
    public T Min;
    public T Max;
}

public static class ObjectsFinder
{
    public static GameObject FindPlayer() => GameObject.FindWithTag("Player");
}
