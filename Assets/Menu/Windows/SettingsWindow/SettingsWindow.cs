using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : Window
{
    public event Action OnBack;
    public event Action OnClearData;
    public event Action OnSwitchLanguage;
    public event Action<SoundData> OnSelectSoundData;

    public const string SettingsWindowName = "Settings";

    [SerializeField] private Button _buttonClearData;
    [SerializeField] private ButtonBack _buttonBack;
    [SerializeField] private Button _buttonLanguage;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    private void Awake()
    {
        WindowName = SettingsWindowName;
        _buttonBack.OnPress += () => OnBack?.Invoke();
        _backgroundWindow.OnClick += () => OnBack?.Invoke();
        _buttonLanguage.onClick.AddListener(() => OnSwitchLanguage?.Invoke());
        _buttonClearData.onClick.AddListener(() => OnClearData?.Invoke());
        _masterSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SettingsData.KeyMixerMaster, value));
        _musicSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SettingsData.KeyMixerMusic, value));
        _soundSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SettingsData.KeyMixerSound, value));
    }

    public void SetValueAudioMixer(float master, float sound, float music)
    {
        _masterSlider.value = master;
        _soundSlider.value = sound;
        _musicSlider.value = music;
    }

    private void ChangeValueHandler(string key, float value)
    {
        OnSelectSoundData?.Invoke(new SoundData(key, value));
    }
}
