using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action OnDead;

    public const string PlayerTag = "Player";

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private InputObserver[] _inputObserver;
    private UseLevelItem _useLevelItem;

    public void Init(InputObserver[] inputObservers)
    {
        _inputObserver = inputObservers;
        foreach (var obs in _inputObserver)
        {
            obs.OnPlayer += _playerMove.MoveHandler;
            obs.OnPlayer += _playerAnimation.AnimHandler;
            obs.OnPlayer += UseHandler;
        }
    }

    public void SetUseLevelItem(UseLevelItem levelItem)
    {
        _useLevelItem = levelItem;
    }

    public void Finish()
    {
        Destroy(gameObject);
    }

    public void Dead()
    {
        OnDead?.Invoke();
        Destroy(gameObject);
    }

    private void UseHandler(PlayerInputData inputData)
    {
        if (inputData.Use && _useLevelItem != null)
        {
            _useLevelItem.Use();
        }
    }

    private void OnDestroy()
    {
        foreach (var obs in _inputObserver)
        {
            obs.OnPlayer -= _playerMove.MoveHandler;
            obs.OnPlayer -= _playerAnimation.AnimHandler;
            obs.OnPlayer -= UseHandler;
        }
    }
}
