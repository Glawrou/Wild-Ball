using System;
using UnityEngine;

public class Star : PlayerTrigger
{
    public event Action OnCollect;

    [SerializeField] private ParticleSystem _collectEffect;
    [SerializeField] private AudioPlay _audioPlay;

    private void Awake()
    {
        OnPlayerEnter += PlayerEnterHandler;
    }

    private void PlayerEnterHandler(Player player)
    {
        var collectEffect = Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
        collectEffect.Play();
        Instantiate(_audioPlay, null).PlayOneShot(AudioPlay.AudioKeyCollect);
        OnCollect?.Invoke();
        Destroy(gameObject);
    }
}
