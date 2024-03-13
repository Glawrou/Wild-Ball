using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;
    [SerializeField] private AudioController _audioController;

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
        LoadScene(SceneManager.GetActiveScene().name);
    }

    protected void LoadScene(string nameScene)
    {
        var scenes = SceneManager.GetSceneByName(nameScene);
        if (!scenes.IsValid())
        {
            Debug.LogError($"There is no scene with this name {nameScene}");
            return;
        }

        SceneManager.LoadScene(scenes.name);
    }
}
