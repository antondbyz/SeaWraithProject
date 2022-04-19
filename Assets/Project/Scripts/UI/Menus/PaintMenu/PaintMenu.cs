using UnityEngine;

public class PaintMenu : MonoBehaviour
{
    [SerializeField] private PaintItemsController _paintsController;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _useButton;
    
    public void BuySelectedSubmarinePaint()
    {
        PaintItem selectedItem = (PaintItem)_paintsController.SelectedItem;
        if(PlayerManager.CrystalsAmount >= selectedItem.PaintObject.Price)
        {
            PlayerManager.CrystalsAmount -= selectedItem.PaintObject.Price;
            SubmarinePaintsManager.MarkItemAsBought(selectedItem);
            UseSelectedSubmarinePaint();
        }
    }

    public void UseSelectedSubmarinePaint()
    {
        PaintItem selectedItem = (PaintItem)_paintsController.SelectedItem;
        SubmarinePaintsManager.SetCurrentItem(selectedItem);
    }

    private void OnEnable()
    {
        _paintsController.ItemSelected += UpdateUI;
        SubmarinePaintsManager.ItemsChanged += UpdateUI;
        PlayerManager.CrystalsChanged -= UpdateUI;
    }

    private void OnDisable()
    {
        _paintsController.ItemSelected -= UpdateUI;
        SubmarinePaintsManager.ItemsChanged -= UpdateUI;
        PlayerManager.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        PaintItem selectedItem = (PaintItem)_paintsController.SelectedItem;
        _buyButton.SetActive(!selectedItem.IsBought && selectedItem.IsEnoughtCrystalsToBuy);
        _useButton.SetActive(selectedItem.IsBought && !selectedItem.IsCurrent);
    }
}
