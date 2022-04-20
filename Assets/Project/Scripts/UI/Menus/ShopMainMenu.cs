using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentSubmarineStatsText;
    [SerializeField] private Image _currentSubmarinePreview;
    [SerializeField] private GameObject _maxLevelLabel;

    private void OnEnable()
    {
        _currentSubmarinePreview.sprite = SubmarinePaintsManager.CurrentPaintObject.Paint;
        _currentSubmarineStatsText.text = $"Armor: {SubmarineStatsManager.CurrentStatsObject.Armor}" +
            $"\nMobility: {SubmarineStatsManager.CurrentStatsObject.Mobility}"; 
        _maxLevelLabel.SetActive(SubmarineStatsManager.NextStatsObject == null);
    }
}
