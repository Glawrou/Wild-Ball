using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;
    [SerializeField] private AudioController _audioController;

    protected static SceneParams SceneParams;

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

    protected void LoadScene(SceneParams sceneParams)
    {
        SceneParams = sceneParams;
        SceneManager.LoadScene(SceneParams.SceneName);
    }
}
