using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectableItem : MonoBehaviour, IPointerDownHandler
{
    public event System.Action<SelectableItem> Selected;

    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.white;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            _image.color = _isSelected ? _selectedColor : _normalColor; 
            if(_isSelected) Selected?.Invoke(this);
        }
    }

    private Image _image;
    private bool _isSelected;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!_isSelected) IsSelected = true;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        IsSelected = false;
    }
}
