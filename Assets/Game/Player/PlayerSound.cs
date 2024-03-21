using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioPlay _audioPlay;

    [Header("Clips")]
    [SerializeField] private AudioClip _stepAudio;
    [SerializeField] private AudioClip _jumpAudio;
    public void PlayStep()
    {
        PlayAudio(_stepAudio);
    }

    public void PlayJump()
    {
        PlayAudio(_jumpAudio);
    }

    public void PlayDie()
    {
        var sound = Instantiate(_audioPlay, null);
        sound.PlayOneShot(AudioPlay.AudioKeyScattering);
    }

    private void PlayAudio(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
}
