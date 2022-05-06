using UnityEngine;

public class SettingsManager : MonoBehaviour, IInitializableOnLoad
{
    public static event System.Action SettingsUpdated;
    public static SettingsData Settings { get; private set; }

    public void Initialize(SaveData initializationData)
    {
        Settings = initializationData.Settings;
    }

    public static void UpdateSettings(SettingsData settings) 
    {
        Settings = settings;
        SettingsUpdated?.Invoke();
    }
}
