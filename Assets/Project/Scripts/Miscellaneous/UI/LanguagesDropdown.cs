using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class LanguagesDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        Sprite[] previews = Resources.LoadAll<Sprite>("Languages");
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for(int i = 0; i < previews.Length; i++)
        {
            options.Add(new TMP_Dropdown.OptionData(previews[i]));
        }
        _dropdown.AddOptions(options);
        _dropdown.value = LocalesManager.CurrentLanguageIndex;
        _dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(int value)
    {
        LocalesManager.LoadLanguage(value);
    }
}
