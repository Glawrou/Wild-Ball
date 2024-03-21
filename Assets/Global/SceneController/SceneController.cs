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
    [SerializeField] private LocalizeController _localizeController;

    protected static SceneParams SceneParams;

    private const int FpsTarget = 60;

    protected void Awake()
    {
        Application.targetFrameRate = FpsTarget;
    }

    protected LevelResultData[] GetLevelsResult()
    {
        return _saveController.Get().PlayerProgressData.levels.ToArray();
    }

    protected void AddResultLevel(int level, int stars)
    {
        var save = _saveController.Get();
        save.PlayerProgressData.AddResult(level, stars);
        _saveController.Save();
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

    protected void SwitchLanguage() => _localizeController.SwitchLanguage();

    protected void LoadSceneForTransite(SceneParams sceneParams)
    {
        LoadScene(new TransitSceneParams(sceneParams));
    }

    protected void LoadScene(SceneParams sceneParams)
    {
        SceneParams = sceneParams;
        SceneManager.LoadScene(SceneParams.SceneName);
    }
}
