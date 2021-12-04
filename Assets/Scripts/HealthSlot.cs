using UnityEngine;
using UnityEngine.UI;

public class HealthSlot : MonoBehaviour
{
    public bool Filled
    {
        get => _filled;
        set
        {
            _filled = value;
            _slotFill.color = _filled ? _filledColor : _notFilledColor;
        }
    }

    [SerializeField] private Image _slotFill = null;
    [SerializeField] private Color _notFilledColor = Color.grey;

    private bool _filled;
    private Color _filledColor;

    private void Awake()
    {
        _filledColor = _slotFill.color;
        Filled = true;
    }
}