using UnityEngine;

[CreateAssetMenu(menuName = "Project/SubmarineObject")]
public class SubmarineObject : ScriptableObject
{
    public bool IsPremium => _isPremium;
    public int Price => _price;
    public Sprite Paint => _paint;
    public int Armor => _armor;
    public int Mobility => _mobility;
    [SerializeField] private bool _isPremium;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _paint;
    [SerializeField] private int _armor;
    [SerializeField] private int _mobility;
}
