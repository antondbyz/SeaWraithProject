using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public abstract class SelectableItem : MonoBehaviour
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

    private void Awake()
    {
        _image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        _controller = transform.parent.GetComponent<SelectableItemsController>();
        IsSelected = false;
    }

    private void OnButtonClick()
    {
        if(!_isSelected) _controller.SelectItem(this);
    }
}
