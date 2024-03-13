using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;
    [SerializeField] private AudioController _audioController;

    protected static SceneParams _sceneParams;

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
        LoadScene(new SceneParams(SceneManager.GetActiveScene().name));
    }

    protected void LoadScene(SceneParams sceneParams)
    {
        _sceneParams = sceneParams;
        SceneManager.LoadScene(_sceneParams.SceneName);
    }
}
