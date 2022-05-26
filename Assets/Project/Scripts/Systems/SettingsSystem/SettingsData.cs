[System.Serializable]
public struct SettingsData
{
    public float MusicVolume { get; private set; }
    public float SoundsVolume { get; private set; }

    public SettingsData(float musicVolume, float soundsVolume)
    {
        MusicVolume = musicVolume;
        SoundsVolume = soundsVolume;
    }
}
