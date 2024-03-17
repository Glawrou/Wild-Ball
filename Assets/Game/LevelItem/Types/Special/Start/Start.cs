using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : LevelItem
{
    [SerializeField] public SpawnPoint[] _spawnPoints;

    public Player Spawn(Player player)
    {
        Player playerOut = null;
        var cellPlayer = Random.Range(0, _spawnPoints.Length);
        for (var i = 0; i < _spawnPoints.Length; i++)
        {
            if (i == cellPlayer)
            {
                playerOut = _spawnPoints[i].Spawn(player);
                continue;
            }
        }

        return playerOut;
    }
}
