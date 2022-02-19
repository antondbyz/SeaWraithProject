using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;

    private void OnEnable()
    {
        UpdateCrystalsText();
        StatsManager.Instance.CrystalsChanged += UpdateCrystalsText;
    }

    private void OnDisable()
    {
        StatsManager.Instance.CrystalsChanged -= UpdateCrystalsText;
    }

    private void UpdateCrystalsText()
    {
        _crystalsText.text = StatsManager.Instance.CrystalsAmount.ToString();
    }
}
