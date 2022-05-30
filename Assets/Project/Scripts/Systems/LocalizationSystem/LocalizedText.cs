using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string localizationKey = "_";
    private TMP_Text _text;

    private void Awake() 
    {
        _text = GetComponent<TMP_Text>();
    } 

    private void OnEnable() 
    {
        LocalesManager.LanguageChanged += UpdateText;
        UpdateText(); 
    }

    private void OnDisable() => LocalesManager.LanguageChanged -= UpdateText;

    private void UpdateText() => _text.text = LocalesManager.GetLocalizedText(localizationKey);
}
