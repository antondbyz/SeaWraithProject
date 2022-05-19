using UnityEngine;

public class SubmarineItemsController : SelectableItemsController
{
    public event System.Action ItemSelected;
    [SerializeField] private SubmarineItem _submarineItem;
    [SerializeField] private SubmarineItem _premiumSubmarineItem;
    private SubmarineItem[] _submarineItems;

    public void Initialize()
    {
        _submarineItems = new SubmarineItem[SubmarinesManager.SubmarineObjects.Length];
        int nextPremiumSubmarineIndex = 0;
        for(int i = 0; i < _submarineItems.Length; i++)
        {
            SubmarineItem newItem;
            if(SubmarinesManager.SubmarineObjects[i].IsPremium == false)
            {
                newItem = Instantiate(_submarineItem, transform);
            }
            else
            {
                newItem = Instantiate(_premiumSubmarineItem, transform);
            }
            newItem.Initialize(SubmarinesManager.SubmarineObjects[i], i);
            _submarineItems[i] = newItem;
            if(newItem.Submarine.IsPremium) 
            {
                newItem.transform.SetSiblingIndex(nextPremiumSubmarineIndex);
                nextPremiumSubmarineIndex++;
            }
        }
        for(int i = 0; i < _submarineItems.Length; i++)
        {
            if(_submarineItems[i].Submarine.IsPremium == false) 
            {
                SelectItem(_submarineItems[i]);
                break;
            }
        }
    }

    protected override void OnItemSelected(SelectableItem item)
    {
        SubmarineItem submarineItem = (SubmarineItem)item;
        ItemSelected?.Invoke();
    }
}
