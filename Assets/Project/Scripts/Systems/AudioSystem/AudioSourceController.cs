using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    [SerializeField] private AudioType _audioType;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        UpdateAudioVolume();
        SettingsManager.SettingsUpdated += UpdateAudioVolume;
    }

    private void OnDisable()
    {
        SettingsManager.SettingsUpdated -= UpdateAudioVolume;
    }

    private void UpdateAudioVolume() 
    {
        switch(_audioType)
        {
            case AudioType.Music:
                _source.volume = SettingsManager.Settings.MusicVolume;
                break;
            case AudioType.Sounds:
                _source.volume = SettingsManager.Settings.SoundsVolume;
                break;
        }
    }
}
