using UnityEngine;

[CreateAssetMenu(menuName = "Project/ScriptableObject/SubmarineItem")]
public class SubmarineItem : ScriptableObject
{
    public int Price => _price;
    public SubmarineStats SubmarineStats => _submarineStats;

    [SerializeField] private int _price;
    [SerializeField] private SubmarineStats _submarineStats;
}
