using UnityEngine;

public abstract class SelectableItemsController : MonoBehaviour
{
    public SelectableItem SelectedItem
    {
        get => _currentItem;
        private set
        {
            if(_currentItem != null) _currentItem.IsSelected = false;
            _currentItem = value;
            _currentItem.IsSelected = true;
        }
    }

    private SelectableItem _currentItem;

    public void SelectItem(SelectableItem item)
    {
        SelectedItem = item;
        OnItemSelected(item);
    }

    protected abstract void OnItemSelected(SelectableItem item);
}
