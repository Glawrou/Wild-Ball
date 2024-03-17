using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsStorage : MonoBehaviour
{
    public int Count => _level.Length;

    [SerializeField] private Level[] _level;

    public Level Init(int levelNumber, GameCamera gameCamera, InputObserver[] inputObservers)
    {
        var level = Instantiate(_level[Mathf.Clamp(levelNumber - 1, 0, _level.Length)]);
        level.Init(gameCamera, inputObservers);
        return level;
    }
}
