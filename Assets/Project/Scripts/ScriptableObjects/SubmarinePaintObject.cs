using UnityEngine;

[CreateAssetMenu(menuName = "SubmarineObjects/SubmarinePaint")]
public class SubmarinePaintObject : ScriptableObject
{
    public int Price => _price;
    public Sprite Paint => _paint;

    [SerializeField] private int _price;
    [SerializeField] private Sprite _paint;
}
