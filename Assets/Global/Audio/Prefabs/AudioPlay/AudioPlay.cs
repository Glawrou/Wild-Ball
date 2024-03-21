using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
        Destroy(gameObject, audioClip.length + 1f);
    }

    public void Play(AudioClip audioClip, bool loop)
    {
        _audioSource.clip = audioClip;
        _audioSource.loop = loop;
        _audioSource.Play();
    }
}
