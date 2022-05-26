using UnityEngine;

public class SubmarineItemsController : SelectableItemsController
{
    public event System.Action ItemSelected;
    [SerializeField] private SubmarineItem _submarineItem;
    private SubmarineItem[] _submarineItems;

    public void Initialize()
    {
        _submarineItems = new SubmarineItem[SubmarinesManager.SubmarineObjects.Length];
        for(int i = 0; i < _submarineItems.Length; i++)
        {
            SubmarineItem newItem = Instantiate(_submarineItem, transform);
            newItem.Initialize(SubmarinesManager.SubmarineObjects[i], i);
            _submarineItems[i] = newItem;
        }
        SelectItem(_submarineItems[SubmarinesManager.CurrentSubmarineIndex]);
    }

    protected override void OnItemSelected(SelectableItem item)
    {
        SubmarineItem submarineItem = (SubmarineItem)item;
        ItemSelected?.Invoke();
    }
}
