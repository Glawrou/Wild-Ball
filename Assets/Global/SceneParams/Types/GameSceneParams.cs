using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneParams : SceneParams
{
    public int LevelNumber { get; private set; }

    private const string Name = "Game";

    public GameSceneParams(int levelNumber) : base(Name)
    {
        LevelNumber = levelNumber;
    }
}
