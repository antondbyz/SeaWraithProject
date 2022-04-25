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
        PlayerProfile.CrystalsAmount -= SubmarineStatsManager.NextStatsObject.Price;
        SubmarineStatsManager.UpgradeCurrentStatsObject();
    }

    private void OnEnable()
    {
        UpdateUI();
        SubmarineStatsManager.CurrentStatsObjectChanged += UpdateUI;
        PlayerProfile.CrystalsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        SubmarineStatsManager.CurrentStatsObjectChanged -= UpdateUI;
        PlayerProfile.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        if(SubmarineStatsManager.NextStatsObject != null)
        {
            bool isEnoughCrystals = PlayerProfile.CrystalsAmount >= SubmarineStatsManager.NextStatsObject.Price;
            _buyButton.SetActive(isEnoughCrystals);
            _notEnoughCrystalsLabel.SetActive(!isEnoughCrystals);
            _priceText.text = $"{SubmarineStatsManager.NextStatsObject.Price}<sprite name=Crystal>";
            _priceText.color = isEnoughCrystals ? Color.green : Color.red;
            int armorProfit = SubmarineStatsManager.NextStatsObject.Armor - SubmarineStatsManager.CurrentStatsObject.Armor;
            int mobilityProfit = SubmarineStatsManager.NextStatsObject.Mobility - SubmarineStatsManager.CurrentStatsObject.Mobility;
            _upgradeInfo.text = $"Armor: <color=green>(+{armorProfit})</color>" +
                                $"\nMobility: <color=green>(+{mobilityProfit})</color>";
        }
    }
}
