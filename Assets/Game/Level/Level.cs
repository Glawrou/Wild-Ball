using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    public event Action<int> OnFinish;
    public event Action OnDead;

    [SerializeField] private int LevelNumber;

    [Space]
    [SerializeField] private Start _start;
    [SerializeField] private Finish _finish;
    [SerializeField] private DeadTrigger _deadTrigger;

    [Space]
    [SerializeField] private Player _playerPrifab;

    private GameCamera _gameCamera;
    private Player _player;

    public void Init(GameCamera gameCamera, InputObserver[] inputObservers)
    {
        _player = _start.Spawn(_playerPrifab);
        _player.Init(inputObservers);
        _gameCamera = gameCamera;
        _gameCamera.SetTarget(_player);
        _deadTrigger.OnDead += () => OnDead?.Invoke();
        _finish.OnFinish += (count) => OnFinish?.Invoke(count);
    }
}
