using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PaintItemsController : SelectableItemsController
{
    public event System.Action ItemSelected;
    [SerializeField] private PaintItem _paintItem;
    private PaintItem[] _paintItems;

    protected override void OnItemSelected(SelectableItem item)
    {
        PaintItem paintItem = (PaintItem)item;
        ItemSelected?.Invoke();
    }

    private void Awake()
    {
        _paintItems = new PaintItem[SubmarinePaintsManager.PaintObjects.Length];
        for(int i = 0 ; i < _paintItems.Length; i++)
        {
            PaintItem newItem = Instantiate(_paintItem, transform);
            newItem.Initialize(SubmarinePaintsManager.PaintObjects[i], i);
            _paintItems[i] = newItem;
        }
        SelectItem(_paintItems[0]);
    }
}
