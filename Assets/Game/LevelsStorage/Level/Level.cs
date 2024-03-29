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
    [SerializeField] private Star[] _stars;

    [Space]
    [SerializeField] private Player _playerPrifab;

    private GameCamera _gameCamera;
    private Player _player;
    private int _starCollectCount = 0;

    public void Init(GameCamera gameCamera, InputObserver[] inputObservers)
    {
        _player = _start.Spawn(_playerPrifab);
        _player.Init(inputObservers);
        _player.OnDead += () => OnDead?.Invoke();
        _gameCamera = gameCamera;
        _gameCamera.SetTarget(_player);
        _finish.OnFinish += (count) => OnFinish?.Invoke(_starCollectCount);

        foreach (var star in _stars)
        {
            star.OnCollect += StarCollectHandler;
        }
    }

    public void StarCollectHandler()
    {
        _starCollectCount++;
    }
}
