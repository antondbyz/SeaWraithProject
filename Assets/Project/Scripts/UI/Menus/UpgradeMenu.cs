using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _upgradeInfo;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _notEnoughCrystalsLabel;

    public void UpgradeSubmarineStats()
    {
        PlayerManager.CrystalsAmount -= SubmarineStatsManager.NextStatsObject.Price;
        SubmarineStatsManager.UpgradeCurrentStatsObject();
    }

    private void OnEnable()
    {
        bool isEnoughCrystals = PlayerManager.CrystalsAmount >= SubmarineStatsManager.NextStatsObject.Price;
        _buyButton.SetActive(isEnoughCrystals);
        _notEnoughCrystalsLabel.SetActive(!isEnoughCrystals);
    }
}
