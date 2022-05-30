using TMPro;
using UnityEngine;

public class BestScoreText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        UpdateUI();
    }

    private void OnEnable()
    {
        LocalesManager.LanguageChanged += UpdateUI;
    }

    private void OnDisable()
    {
        LocalesManager.LanguageChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _text.text = $"{LocalesManager.GetLocalizedText("_bestScore")}: {PlayerProfile.BestScore}";
    }
}
