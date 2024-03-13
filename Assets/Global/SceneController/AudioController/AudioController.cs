using UnityEngine;
using UnityEngine.Audio;

public abstract class AudioController : MonoBehaviour
{
    [SerializeField] protected AudioMixer _audioMixer;

    public abstract void Set(SoundData soundData);

    public abstract SoundData Get(string key);
}
