using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public const string KeyMixerMaster = "Master";
    public const string KeyMixerSound = "Sound";
    public const string KeyMixerMusic = "Music";

    protected void SetAudioMixer(SoundData _soundData)
    {
        _audioMixer.SetFloat(_soundData.Key, _soundData.Value);
    }

    protected float GetValueAudioMixer(string key)
    {
        var value = -1f;
        _audioMixer.GetFloat(key, out value);
        return 1;
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
