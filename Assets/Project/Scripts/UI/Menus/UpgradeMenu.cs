using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _upgradeInfo;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _notEnoughCrystalsLabel;

    public void UpgradeSubmarineStats()
    {
        PlayerManager.CrystalsAmount -= SubmarineStatsManager.NextStatsObject.Price;
        SubmarineStatsManager.UpgradeCurrentStatsObject();
    }

    private void OnEnable()
    {
        UpdateUI();
        SubmarineStatsManager.CurrentStatsObjectChanged += UpdateUI;
        PlayerManager.CrystalsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        SubmarineStatsManager.CurrentStatsObjectChanged -= UpdateUI;
        PlayerManager.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        bool isEnoughCrystals = PlayerManager.CrystalsAmount >= SubmarineStatsManager.NextStatsObject.Price;
        _buyButton.SetActive(isEnoughCrystals);
        _notEnoughCrystalsLabel.SetActive(!isEnoughCrystals);
        _priceText.text = $"{SubmarineStatsManager.NextStatsObject.Price}<sprite name=Crystal>";
        _priceText.color = isEnoughCrystals ? Color.green : Color.red;
        int currentArmor = SubmarineStatsManager.CurrentStatsObject.Armor;
        int currentMobility = SubmarineStatsManager.CurrentStatsObject.Mobility;
        int armorProfit = SubmarineStatsManager.NextStatsObject.Armor - currentArmor;
        int mobilityProfit = SubmarineStatsManager.NextStatsObject.Mobility - currentMobility;
        _upgradeInfo.text = $"Armor: {currentArmor} <color=green>(+{armorProfit})</color>" +
                            $"\nMobility: {currentMobility} <color=green>(+{mobilityProfit})</color>";
    }
}
