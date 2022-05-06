using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private SubmarineItemsController _itemsController;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _useButton;
    
    public void BuySelectedSubmarine()
    {
        SubmarineItem selectedItem = (SubmarineItem)_itemsController.SelectedItem;
        if(PlayerProfile.CrystalsAmount >= selectedItem.Submarine.Price)
        {
            PlayerProfile.CrystalsAmount -= selectedItem.Submarine.Price;
            SubmarinesManager.MarkItemAsBought(selectedItem);
            UseSelectedSubmarine();
        }
    }

    public void UseSelectedSubmarine()
    {
        SubmarineItem selectedItem = (SubmarineItem)_itemsController.SelectedItem;
        SubmarinesManager.SetCurrentItem(selectedItem);
    }

    private void Awake()
    {
        _itemsController.Initialize();
    }

    private void OnEnable()
    {
        UpdateUI();
        _itemsController.ItemSelected += UpdateUI;
        SubmarinesManager.Changed += UpdateUI;
        PlayerProfile.CrystalsChanged -= UpdateUI;
    }

    private void OnDisable()
    {
        _itemsController.ItemSelected -= UpdateUI;
        SubmarinesManager.Changed -= UpdateUI;
        PlayerProfile.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        SubmarineItem selectedItem = (SubmarineItem)_itemsController.SelectedItem;
        _buyButton.SetActive(!selectedItem.IsBought && selectedItem.IsEnoughtCrystalsToBuy);
        _useButton.SetActive(selectedItem.IsBought && !selectedItem.IsCurrent);
    }
}
