using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;
    [Header("Replaceable Upgrade button")]
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private GameObject _maxLevelText;
    [Header("Replaceable YesUpgrade button")]
    [SerializeField] private GameObject _yesUpgradeButton; 
    [SerializeField] private GameObject _notEnoughCrystalsText;
    [Header("Current submarine item info")]
    [SerializeField] private TMP_Text _currentSubmarineArmorText;
    [SerializeField] private TMP_Text _currentSubmarineMobilityText;
    [Header("Next submarine item info")]
    [SerializeField] private TMP_Text _nextSubmarineArmorText;
    [SerializeField] private TMP_Text _nextSubmarineMobilityText;
    [SerializeField] private TMP_Text _nextSubmarinePrice;

    public void BuyNextSubmarineItem()
    {
        SubmarineItemsManager.SetCurrentSubmarineItemToNext();
        StatsManager.CrystalsAmount -= SubmarineItemsManager.CurrentSubmarineItem.Price;
    }

    private void OnEnable()
    {
        UpdateUI();
        StatsManager.CrystalsChanged += UpdateUI;
        SubmarineItemsManager.CurrentSubmarineChanged += UpdateUI;
    }

    private void OnDisable()
    {
        StatsManager.CrystalsChanged -= UpdateUI;
        SubmarineItemsManager.CurrentSubmarineChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _crystalsText.text = StatsManager.CrystalsAmount.ToString();

        int currentSubmarineArmor = SubmarineItemsManager.CurrentSubmarineItem.SubmarineStats.Armor;
        float currentSubmarineMobility = SubmarineItemsManager.CurrentSubmarineItem.SubmarineStats.Mobility;
        _currentSubmarineArmorText.text = $"Armor: {currentSubmarineArmor}";
        _currentSubmarineMobilityText.text = $"Mobility: {currentSubmarineMobility}";

        bool isThereNextSubmarineItem = SubmarineItemsManager.NextSubmarineItem != null;
        _upgradeButton.SetActive(isThereNextSubmarineItem);
        _maxLevelText.SetActive(!isThereNextSubmarineItem);
        if (isThereNextSubmarineItem) 
        {
            int nextSubmarineArmor = SubmarineItemsManager.NextSubmarineItem.SubmarineStats.Armor;
            _nextSubmarineArmorText.text = $"Armor: +{nextSubmarineArmor - currentSubmarineArmor}";
            float nextSubmarineMobility = SubmarineItemsManager.NextSubmarineItem.SubmarineStats.Mobility;
            _nextSubmarineMobilityText.text = $"Mobility: +{nextSubmarineMobility - currentSubmarineMobility}";
            _nextSubmarinePrice.text = $"Price: {SubmarineItemsManager.NextSubmarineItem.Price}";
            bool isEnoughCrystals = StatsManager.CrystalsAmount >= SubmarineItemsManager.NextSubmarineItem.Price;
            _yesUpgradeButton.SetActive(isEnoughCrystals);
            _notEnoughCrystalsText.SetActive(!isEnoughCrystals);
        }
    }
}
