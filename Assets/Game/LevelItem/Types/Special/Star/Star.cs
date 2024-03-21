using System;
using UnityEngine;

public class Star : PlayerTrigger
{
    public event Action OnCollect;

    [SerializeField] private ParticleSystem _collectEffect;

    private void Awake()
    {
        OnPlayerEnter += PlayerEnterHandler;
    }

    private void PlayerEnterHandler(Player player)
    {
        Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
        OnCollect?.Invoke();
        Destroy(gameObject);
    }
}
