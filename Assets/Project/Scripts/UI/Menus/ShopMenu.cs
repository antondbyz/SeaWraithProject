using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;
    [SerializeField] private TMP_Text _statsText;
    [Header("Upgrade button")]
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private TMP_Text _upgradeButtonText;
    [Space]
    [SerializeField] private GameObject _maxLevelLabel;

    public void UpgradeSubmarine()
    {
        if(PlayerManager.CrystalsAmount >= SubmarineStatsManager.NextStatsObject.Price)
        {
            PlayerManager.CrystalsAmount -= SubmarineStatsManager.NextStatsObject.Price;
            SubmarineStatsManager.UpgradeCurrentStatsObject();
        }
    }

    private void OnEnable()
    {
        UpdateUI();
        PlayerManager.CrystalsChanged += UpdateUI;
        SubmarineStatsManager.CurrentStatsObjectChanged += UpdateUI;
    }

    private void OnDisable()
    {
        PlayerManager.CrystalsChanged -= UpdateUI;
        SubmarineStatsManager.CurrentStatsObjectChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _crystalsText.text = PlayerManager.CrystalsAmount.ToString();
        int currentArmor = SubmarineStatsManager.CurrentStatsObject.Armor;
        int currentMobility = SubmarineStatsManager.CurrentStatsObject.Mobility;
        string nextArmorText = "";
        string nextMobilityText = "";
        bool isThereNextSubmarineItem = SubmarineStatsManager.NextStatsObject != null;
        _upgradeButton.SetActive(isThereNextSubmarineItem);
        _maxLevelLabel.SetActive(!isThereNextSubmarineItem);
        if (isThereNextSubmarineItem) 
        {
            nextArmorText = $"(+{SubmarineStatsManager.NextStatsObject.Armor - currentArmor})";
            nextMobilityText = $"(+{SubmarineStatsManager.NextStatsObject.Mobility - currentMobility})";
            bool isEnoughCrystals = PlayerManager.CrystalsAmount >= SubmarineStatsManager.NextStatsObject.Price;
            string upgradeTextColor = isEnoughCrystals ? "green" : "red";
            string priceText = $"{SubmarineStatsManager.NextStatsObject.Price}";
            _upgradeButtonText.text = $"Upgrade <color={upgradeTextColor}>({priceText})</color><sprite name=Crystal>";
        }
        _statsText.text = $"Armor: {currentArmor} <color=green>{nextArmorText}</color>" +
                            $"\nMobility: {currentMobility} <color=green>{nextMobilityText}</color>";
    }
}
