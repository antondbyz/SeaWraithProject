using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectableItem : MonoBehaviour, IPointerClickHandler
{
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            _image.color = _isSelected ? _selectedColor : _normalColor; 
            if(_isSelected) _controller.OnItemSelected(this);
        }
    }

    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _selectedColor = Color.white;

    private Image _image;
    private SelectableItemsController _controller;
    private bool _isSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_isSelected) IsSelected = true;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _controller = transform.parent.GetComponent<SelectableItemsController>();
        IsSelected = transform.GetSiblingIndex() == 0;
    }
}
