using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseLevelItem : LevelItem
{
    [SerializeField] private PlayerTrigger _playerTrigger;

    private void Awake()
    {
        _playerTrigger.OnPlayerEnter += PlayerEnterHandler;
        _playerTrigger.OnPlayerExit += PlayerExitHandler;
    }

    public abstract void Use();

    private void PlayerEnterHandler(Player player)
    {
        player.SetUseLevelItem(this);
    }

    private void PlayerExitHandler(Player player)
    {
        player.SetUseLevelItem(null);
    }
}
