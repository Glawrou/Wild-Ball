using System.Linq;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioData[] _audioDatas;

    public const string AudioKeyClick = "Click";
    public const string AudioKeyCollect = "Collect";
    public const string AudioKeyJump = "Jump";
    public const string AudioKeyLevelLose = "LevelLose";
    public const string AudioKeyScattering = "Scattering";
    public const string AudioKeyStep = "Step";
    public const string AudioKeyWin = "Win";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(string key)
    {
        if (!_audioDatas.Any(a => a.Key == key))
        {
            Debug.LogError("AudioPlay >> PlayOneShot >> AudioData not found");
            return;
        }

        var audio = _audioDatas.FirstOrDefault(a => a.Key == key);
        PlayOneShot(audio.AudioClip, audio.Volume);
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        PlayOneShot(audioClip, 1);
    }

    public void PlayOneShot(AudioClip audioClip, float volume)
    {
        _audioSource.PlayOneShot(audioClip);
        _audioSource.volume = volume;
        Destroy(gameObject, audioClip.length + 1f);
    }

    public void Play(AudioClip audioClip, bool loop)
    {
        _audioSource.clip = audioClip;
        _audioSource.loop = loop;
        _audioSource.Play();
    }
}
