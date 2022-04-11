using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;
    [Header("Garage menu")]
    [SerializeField] private TMP_Text _statsText;
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private GameObject _maxLevelLabel;

    public void UpgradeSubmarine()
    {
        SubmarineItemsManager.CurrentSubmarineItemIndex++;
        PlayerStatsManager.CrystalsAmount -= SubmarineItemsManager.CurrentSubmarineItem.Price;
    }

    private void OnEnable()
    {
        UpdateUI();
        PlayerStatsManager.CrystalsChanged += UpdateUI;
        SubmarineItemsManager.CurrentSubmarineChanged += UpdateUI;
    }

    private void OnDisable()
    {
        PlayerStatsManager.CrystalsChanged -= UpdateUI;
        SubmarineItemsManager.CurrentSubmarineChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _crystalsText.text = PlayerStatsManager.CrystalsAmount.ToString();

        int currentSubmarineArmor = SubmarineItemsManager.CurrentSubmarineItem.SubmarineStats.Armor;
        float currentSubmarineMobility = SubmarineItemsManager.CurrentSubmarineItem.SubmarineStats.Mobility;
        _statsText.text = $"Armor: {currentSubmarineArmor}\nMobility: {currentSubmarineMobility}";

        bool isThereNextSubmarineItem = SubmarineItemsManager.NextSubmarineItem != null;
        _upgradeButton.SetActive(isThereNextSubmarineItem);
        _maxLevelLabel.SetActive(!isThereNextSubmarineItem);
        if (isThereNextSubmarineItem) 
        {
            bool isEnoughCrystals = PlayerStatsManager.CrystalsAmount >= SubmarineItemsManager.NextSubmarineItem.Price;
        }
    }
}
