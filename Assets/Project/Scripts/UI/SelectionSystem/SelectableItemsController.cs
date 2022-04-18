using UnityEngine;

public class SelectableItemsController : MonoBehaviour
{
    public event System.Action CurrentItemChanged;
    public SelectableItem CurrentItem
    {
        get => _currentItem;
        private set
        {
            if(_currentItem != null) _currentItem.IsSelected = false;
            bool isNewValue = _currentItem != value;
            _currentItem = value;
            if(isNewValue) CurrentItemChanged?.Invoke();
        }
    }

    private SelectableItem _currentItem;

    public void OnItemSelected(SelectableItem item)
    {
        CurrentItem = item;
    }
}
