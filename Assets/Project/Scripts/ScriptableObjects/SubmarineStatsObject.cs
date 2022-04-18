using UnityEngine;

[CreateAssetMenu(menuName = "SubmarineObjects/SubmarineStats")]
public class SubmarineStatsObject : ScriptableObject
{
    public int Price => _price;
    public int Armor => _armor;
    public int Mobility => _mobility;

    [SerializeField] private int _price;
    [SerializeField] private int _armor;
    [SerializeField] private int _mobility;
}
