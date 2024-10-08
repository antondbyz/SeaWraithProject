using UnityEngine;

[CreateAssetMenu(menuName = "Project/SubmarineObject")]
public class SubmarineObject : ScriptableObject
{
    public int Price => _price;
    public Sprite Paint => IAPManager.IsPremiumPurchased ? _premiumPaint : _paint;
    public int Armor => _armor;
    public int Mobility => _mobility;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _paint;
    [SerializeField] private Sprite _premiumPaint;
    [SerializeField] private int _armor;
    [SerializeField] private int _mobility;
}
