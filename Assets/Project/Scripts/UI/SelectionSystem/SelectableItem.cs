using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class SelectableItem : MonoBehaviour, IPointerClickHandler
{
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            _image.color = _isSelected ? _selectedColor : _normalColor; 
        }
    }

    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.white;

    private Image _image;
    private SelectableItemsController _controller;
    private bool _isSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_isSelected) _controller.SelectItem(this);
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _controller = transform.parent.GetComponent<SelectableItemsController>();
        IsSelected = false;
    }
}
