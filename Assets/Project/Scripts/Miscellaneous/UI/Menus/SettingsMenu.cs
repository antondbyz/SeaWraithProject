using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;

    private void OnEnable()
    {
        _musicSlider.value = SettingsManager.Settings.MusicVolume;
        _soundsSlider.value = SettingsManager.Settings.SoundsVolume;
        _musicSlider.onValueChanged.AddListener(OnSettingsChanged);
        _soundsSlider.onValueChanged.AddListener(OnSettingsChanged);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(OnSettingsChanged);
        _soundsSlider.onValueChanged.RemoveListener(OnSettingsChanged);
    }

    private void OnSettingsChanged(float value)
    {
        SettingsData settings  = new SettingsData(_musicSlider.value, _soundsSlider.value);
        SettingsManager.UpdateSettings(settings);
    }
}
