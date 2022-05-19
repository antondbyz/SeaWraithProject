using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private SubmarineItemsController _itemsController;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _useButton;
    [SerializeField] private GameObject _premiumButton;
    [SerializeField] private GameObject _buyPremiumItemButton;
    
    public void BuySelectedSubmarine()
    {
        SubmarineItem selectedItem = (SubmarineItem)_itemsController.SelectedItem;
        if(PlayerProfile.CrystalsAmount >= selectedItem.Submarine.Price)
        {
            PlayerProfile.CrystalsAmount -= selectedItem.Submarine.Price;
            SubmarinesManager.MarkSubmarineAsBought(selectedItem.Index);
            UseSelectedSubmarine();
        }
    }

    public void UseSelectedSubmarine()
    {
        SubmarineItem selectedItem = (SubmarineItem)_itemsController.SelectedItem;
        SubmarinesManager.SetCurrentSubmarineIndex(selectedItem.Index);
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
        _buyButton.SetActive(!selectedItem.IsBought && selectedItem.IsEnoughtCrystalsToBuy && !selectedItem.IsPremium);
        _useButton.SetActive(selectedItem.IsBought && !selectedItem.IsCurrent);
        _buyPremiumItemButton.SetActive(selectedItem.IsPremium && !selectedItem.IsBought);
        _premiumButton.SetActive(!_buyPremiumItemButton.activeSelf);
    }
}
