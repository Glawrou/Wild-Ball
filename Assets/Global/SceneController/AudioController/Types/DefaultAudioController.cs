using UnityEngine;
using UnityEngine.Audio;

public class DefaultAudioController : AudioController
{
    [SerializeField] private SaveController _saveController;

    private void Awake()
    {
        InitSave();
    }

    public override SoundData Get(string key)
    {
        var save = _saveController.Get();
        return new SoundData(key, save.SettingsData.GetValueAudio(key));
    }

    public override void Set(SoundData soundData)
    {
        var save = _saveController.Get();
        save.SettingsData.SetValueAudio(soundData);
        _saveController.Set(save);
        SetAudioMixer(soundData);
    }

    private void SetAudioMixer(SoundData soundData)
    {
        _audioMixer.SetFloat(soundData.Key, soundData.ValueInt);
    }

    private void InitSave()
    {
        var save = _saveController.Get();
        SetAudioMixer(new SoundData(SettingsData.KeyMixerMaster, save.SettingsData.ValueAudioMaster));
        SetAudioMixer(new SoundData(SettingsData.KeyMixerMusic, save.SettingsData.ValueAudioMusic));
        SetAudioMixer(new SoundData(SettingsData.KeyMixerSound, save.SettingsData.ValueAudioSound));
    }
}
