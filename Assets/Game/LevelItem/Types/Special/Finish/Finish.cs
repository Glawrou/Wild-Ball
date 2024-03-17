using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : LevelItem
{
    public event Action<int> OnFinish;

    private int _countPlayers = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != Player.PlayerTag)
        {
            return;
        }

        var player = other.GetComponent<Player>();
        player.Dead();
        OnFinish?.Invoke(_countPlayers++);
    }
}
