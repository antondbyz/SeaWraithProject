using System.Collections.Generic;
using UnityEngine;

public class LocalesManager : MonoBehaviour, IInitializableOnLoad
{
    public static event System.Action LanguageChanged;
    public static int CurrentLanguageIndex;
    private static Dictionary<string, string> _localizedText = new Dictionary<string, string>();
    private static TextAsset[] _languages;

    public static string GetLocalizedText(string key)
    {
        string result = "";
        if(_localizedText.ContainsKey(key)) result = _localizedText[key];
        return result;
    }

    public static void LoadLanguage(int languageIndex)
    {
        string languageData = _languages[languageIndex].text;
        Locale locale = JsonUtility.FromJson<Locale>(languageData);
        _localizedText.Clear();
        for (int i = 0; i < locale.LocaleData.Length; i++)
        {
            _localizedText.Add(locale.LocaleData[i].Key, locale.LocaleData[i].Value);
        }
        LanguageChanged?.Invoke();
        CurrentLanguageIndex = languageIndex;
    }

    public void Initialize(SaveData initializationData)
    {
        CurrentLanguageIndex = initializationData.CurrentLanguageIndex;
        _languages = Resources.LoadAll<TextAsset>("Languages");
        LoadLanguage(CurrentLanguageIndex);
    }
}
