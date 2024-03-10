using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : Window
{
    public event Action OnBack;
    public event Action<SoundData> OnSelectSoundData;

    public const string SettingsWindowName = "Settings";

    [SerializeField] private ButtonBack _buttonBack;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    private void Awake()
    {
        WindowName = SettingsWindowName;
        _buttonBack.OnPress += () => OnBack?.Invoke();
        _backgroundWindow.OnClick += () => OnBack?.Invoke();
        _masterSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SceneController.KeyMixerMaster, value));
        _musicSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SceneController.KeyMixerMusic, value));
        _soundSlider.onValueChanged
            .AddListener((value) => ChangeValueHandler(SceneController.KeyMixerSound, value));
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
