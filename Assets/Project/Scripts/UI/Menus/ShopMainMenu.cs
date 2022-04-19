using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _statsText;
    [SerializeField] private Image _currentSubmarinePreview;
    [SerializeField] private GameObject _maxLevelLabel;

    private void OnEnable()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _currentSubmarinePreview.sprite = SubmarinePaintsManager.CurrentPaintObject.Paint;
        _statsText.text = $"Armor: {SubmarineStatsManager.CurrentStatsObject.Armor}" +
                            $"\nMobility: {SubmarineStatsManager.CurrentStatsObject.Mobility}";
        _maxLevelLabel.SetActive(SubmarineStatsManager.NextStatsObject == null);
        string nextArmorText = "";
        string nextMobilityText = "";
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
