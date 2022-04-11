using UnityEngine;

public class SelectableItemsController : MonoBehaviour
{
    public SelectableItem CurrentItem
    {
        get => _currentItem;
        private set
        {
            if(_currentItem != null) _currentItem.IsSelected = false;
            _currentItem = value;
        }
    }

    private SelectableItem[] _items;
    private SelectableItem _currentItem;

    private void Awake()
    {
        _items = GetComponentsInChildren<SelectableItem>();
        CurrentItem = _items[0];
        CurrentItem.IsSelected = true;
    }

    private void OnEnable()
    {
        for(int i = 0; i < _items.Length; i++)
        {
            _items[i].Selected += OnItemSelected;
        }    
    }

    private void OnDisable()
    {
        for(int i = 0; i < _items.Length; i++)
        {
            _items[i].Selected -= OnItemSelected;
        }
    }

    private void OnItemSelected(SelectableItem item)
    {
        CurrentItem = item;
    }
}
