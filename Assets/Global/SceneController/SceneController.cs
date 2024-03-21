using UnityEngine;
using UnityEngine.Audio;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;
    [SerializeField] private AudioController _audioController;

    protected static SceneParams SceneParams;

    private int _localeIndex = 0;

    private void Awake()
    {
        var locales = LocalizationSettings.AvailableLocales.Locales.ToArray();
        _localeIndex = Array.IndexOf(locales, LocalizationSettings.SelectedLocale);
    }

    protected void ClearSave()
    {
        _saveController.Clear();
        ReloadScene();
    }

    protected void SetAudioMixer(SoundData _soundData) => _audioController.Set(_soundData);

    protected float GetValueAudioMixer(string key)
    {
        return _audioController.Get(key).Value;
    }

    protected void ApplicationExit()
    {
        Application.Quit();
    }

    protected void ReloadScene()
    {
        LoadScene(SceneParams);
    }

    protected void SwitchLanguage()
    {
        _localeIndex = _localeIndex + 1 >= LocalizationSettings.AvailableLocales.Locales.Count ? 0 : _localeIndex + 1;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeIndex];
    }

    protected void LoadScene(SceneParams sceneParams)
    {
        SceneParams = sceneParams;
        SceneManager.LoadScene(SceneParams.SceneName);
    }
}
