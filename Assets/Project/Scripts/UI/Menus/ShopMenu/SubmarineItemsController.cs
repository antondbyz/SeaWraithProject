using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SubmarineItemsController : SelectableItemsController
{
    public event System.Action ItemSelected;
    [SerializeField] private SubmarineItem _submarineItem;
    private SubmarineItem[] _submarineItems;

    protected override void OnItemSelected(SelectableItem item)
    {
        SubmarineItem submarineItem = (SubmarineItem)item;
        ItemSelected?.Invoke();
    }

    private void Awake()
    {
        _submarineItems = new SubmarineItem[SubmarinesManager.SubmarineObjects.Length];
        for(int i = 0 ; i < _submarineItems.Length; i++)
        {
            SubmarineItem newItem = Instantiate(_submarineItem, transform);
            newItem.Initialize(SubmarinesManager.SubmarineObjects[i], i);
            _submarineItems[i] = newItem;
        }
        SelectItem(_submarineItems[0]);
    }
}
