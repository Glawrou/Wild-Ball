using System;
using UnityEngine;

[Serializable]
public class SettingsData
{
    public float ValueAudioMaster;
    public float ValueAudioMusic;
    public float ValueAudioSound;

    public const string KeyMixerMaster = "Master";
    public const string KeyMixerSound = "Sound";
    public const string KeyMixerMusic = "Music";

    public SettingsData()
    {
        ValueAudioMaster = 1;
        ValueAudioMusic = 1;
        ValueAudioSound = 1;
    }

    public void SetValueAudio(SoundData soundData)
    {
        SetValueAudio(soundData.Key, soundData.Value);
    }

    public void SetValueAudio(string key, float value)
    {
        switch (key)
        {
            case KeyMixerMaster:
                ValueAudioMaster = value;
                break;
            case KeyMixerMusic:
                ValueAudioMusic = value;
                break;
            case KeyMixerSound:
                ValueAudioSound = value;
                break;
            default:
                Debug.LogError("SettingsData >> SetValueAudio >> Key not found");
                break;
        }
    }

    public float GetValueAudio(string key)
    {
        switch (key)
        {
            case KeyMixerMaster:
                return ValueAudioMaster;
            case KeyMixerMusic:
                return ValueAudioMusic;
            case KeyMixerSound:
                return ValueAudioSound;
            default:
                Debug.LogError("SettingsData >> GetValueAudio >> Key not found");
                return 0;
        }
    }
}
