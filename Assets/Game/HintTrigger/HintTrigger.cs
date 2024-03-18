using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : PlayerTrigger
{
    [SerializeField] private string HintName;

    private void Awake()
    {
        OnPlayerEnter += (player) => Hints.Open(HintName);
        OnPlayerExit += (player) => Hints.Close(HintName);
    }
}
